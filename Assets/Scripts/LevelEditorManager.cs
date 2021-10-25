using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Events;

public class LevelEditorManager : MonoBehaviour
{
    void Awake()
    {
        //load the level in for editing
        LevelSerializationManager.LoadAndSpawnLevel();
    }

    public UnityEvent Saves;

    public void SavePressed()
    {
        LevelSerializationManager.SerializeLevel();
        //send out event signal for the observer later
        Saves.Invoke();
        
    }

    private void MainMenuPressed()
    {
        //expand on this with observer later
        SceneManager.LoadScene("MainMenu");
    }

    //runs every frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            SavePressed();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MainMenuPressed();
        }
    }
}
