using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TESTSAVE : MonoBehaviour
{
    public PuzzleProgress TEST;

    public void TEST_IncreaseCounter()
    {
        TEST.collectedPieces++;
        TEST.UpdateUI();
    }
}
