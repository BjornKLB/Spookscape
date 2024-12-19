using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextEffects : MonoBehaviour
{
    [SerializeField] TMP_Text textComponent;

    [Serializable]
    public class SpecialWordAnimation
    {
        public int wordIndex; // The index of the word in the text
        public AnimationType animationType; // The type of animation to apply
    }

    public enum AnimationType
    {
        Wave,
        Shake
    }

    [SerializeField] List<SpecialWordAnimation> specialWordAnimations;

    private void Update()
    {
        if (textComponent == null || specialWordAnimations.Count == 0)
            return;

        textComponent.ForceMeshUpdate();
        var textInfo = textComponent.textInfo;

        foreach (var specialWord in specialWordAnimations)
        {
            if (specialWord.wordIndex < 0 || specialWord.wordIndex >= textInfo.wordCount)
            {
                Debug.LogWarning($"Invalid word index {specialWord.wordIndex}");
                continue;
            }

            var wordInfo = textInfo.wordInfo[specialWord.wordIndex];
            int lastCharacterIndex = wordInfo.firstCharacterIndex + wordInfo.characterCount - 1;

            // If it's the last word, include punctuation
            if (specialWord.wordIndex == textInfo.wordCount - 1)
            {
                for (int j = lastCharacterIndex + 1; j < textInfo.characterCount; j++)
                {
                    var charInfo = textInfo.characterInfo[j];
                    if (charInfo.isVisible && char.IsPunctuation(charInfo.character))
                    {
                        lastCharacterIndex = j;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            // Apply animation to the word
            for (int k = wordInfo.firstCharacterIndex; k <= lastCharacterIndex; k++)
            {
                var charInfo = textInfo.characterInfo[k];
                if (!charInfo.isVisible) continue;

                var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

                for (int j = 0; j < 4; j++)
                {
                    var orig = verts[charInfo.vertexIndex + j];
                    verts[charInfo.vertexIndex + j] = orig + GetAnimationOffset(specialWord.animationType, orig, Time.time);
                }
            }

            // Update mesh geometry
            for (int k = 0; k < textInfo.meshInfo.Length; k++)
            {
                var meshInfo = textInfo.meshInfo[k];
                meshInfo.mesh.vertices = meshInfo.vertices;
                textComponent.UpdateGeometry(meshInfo.mesh, k);
            }
        }
    }

    private Vector3 GetAnimationOffset(AnimationType type, Vector3 originalPosition, float time)
    {
        switch (type)
        {
            case AnimationType.Wave:
                return new Vector3(0, Mathf.Sin(time * 2f + originalPosition.x * 0.01f) * 10f, 0);
            case AnimationType.Shake:
                return new Vector3(Mathf.PerlinNoise(time * 5f, originalPosition.x) * 15f - 2.5f, Mathf.PerlinNoise(time * 5f, originalPosition.y) * 15f - 2.5f, 0);
            default:
                return Vector3.zero;
        }
    }
}
