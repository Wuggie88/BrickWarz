using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBacktrackScript : MonoBehaviour
{
    public GameObject selector;

    //Remebers the selector
    public void SetSelector(GameObject holder)
    {
        selector = holder;
    }

    //Called when you want to back undo selection
    public void BackTrack()
    {
        selector.SetActive(true);
    }
}
