using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//based on observer pattern video : https://youtu.be/UWMmib1RYFE

public class ChangeUpdate : MonoBehaviour
{
    
    public Text UnsaveUI;
    bool SavedState;

    private void Start()
    {
        UnsaveUI.text = "Saved";
    }

    //subscribes to delegate
    private void OnEnable()
    {
        SpawnDetect.ObjectChanged += UpdateSave;
    }

    //Unsibscribes to delegate
    private void OnDisable()
    {
        SpawnDetect.ObjectChanged -= UpdateSave;
    }

    //change text to unsaved
    public void UpdateSave()
    {
       UnsaveUI.text = "Unsaved Changes";
        SavedState = false;
    }

    //change text to saved
    public void Saved()
    {
        UnsaveUI.text = "Saved";
        SavedState = true;
    }
}
