using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericPuzzleClass : MonoBehaviour
{
    [SerializeField] GameObject puzzleBaseObject;

    public void OnPuzzleStarted()
    {
        StartCoroutine(IEDelay(true));
    }

    public virtual void OnPuzzleClosed()
    {
        StartCoroutine(IEDelay(false));
    }

    private IEnumerator IEDelay(bool active)
    {
        yield return new WaitForSeconds(1); 
        puzzleBaseObject.SetActive(active);
    }
}
