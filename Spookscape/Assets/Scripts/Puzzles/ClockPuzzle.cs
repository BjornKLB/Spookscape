using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClockPuzzle : GenericPuzzleClass
{
    [SerializeField] GameObject hintDialogue;
    public void ReadHint()
    {
        hintDialogue.SetActive(true);
        StartCoroutine("CloseHint");
    }

    private IEnumerator CloseHint()
    {
        yield return new WaitForSeconds(5);
        hintDialogue.SetActive(false);
    }

    public override void OnPuzzleClosed()
    {
        base.OnPuzzleClosed();
        hintDialogue.SetActive(false); 
    }
}
