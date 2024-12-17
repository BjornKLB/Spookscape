using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class PuzzleProgress : MonoBehaviour
{
    [Header("General Variables")]
    [SerializeField] public int collectedPieces;
    [SerializeField] TextMeshProUGUI pieceCounter;

    private void Start()
    {
        string path = Application.persistentDataPath + "/progress.nvk";
        if (File.Exists(path))
        {
            PuzzleData data = SavingSystem.LoadProgress();

            // Load general variables
            collectedPieces = data.collectedPieces;

            UpdateUI();
        }
    }

    public void UpdateUI()
    {
        pieceCounter.text = collectedPieces.ToString();
        SavingSystem.SaveProgress(this);
    }
}
