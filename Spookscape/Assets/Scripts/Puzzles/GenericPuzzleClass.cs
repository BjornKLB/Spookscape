using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericPuzzleClass : MonoBehaviour
{
    [SerializeField] GameObject puzzleBaseObject;

    public void OnPuzzleStarted()
    {
        puzzleBaseObject.SetActive(true);
        Debug.Log("Puzzle Started");
    }

    public virtual void OnPuzzleClosed()
    {
        puzzleBaseObject.SetActive(false);
        Debug.Log("Puzzle Closed");
    }
}
