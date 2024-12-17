using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

[System.Serializable]
public class PuzzleData
{
    // general variables
    public int collectedPieces;

    // inventory

    // puzzle 1

    // puzzle 2

    public PuzzleData(PuzzleProgress progress)
    {
        collectedPieces = progress.collectedPieces;
    }
}