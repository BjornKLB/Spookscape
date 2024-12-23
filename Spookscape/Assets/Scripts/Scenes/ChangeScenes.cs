using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeScenes : MonoBehaviour
{
    [SerializeField] GameObject[] sceneObjects;
    [SerializeField] GameObject fadeImage;

    private void HideAllScenes()
    {
        foreach (GameObject sceneObject in sceneObjects) sceneObject.SetActive(false);
    }

    public void ShowScene(GameObject sceneObject)
    {
        fadeImage.GetComponent<Animator>().Play("FadeOutShutter", -1, 0);
        StartCoroutine(IECooldown(sceneObject));
    }

    private IEnumerator IECooldown(GameObject sceneObject)
    {
        yield return new WaitForSeconds(1.1f);
        HideAllScenes();
        fadeImage.GetComponent<Animator>().Play("FadeInUpwards", -1, 0);
        sceneObject.SetActive(true);
    }
}
