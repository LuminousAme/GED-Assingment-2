using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEditorManager : MonoBehaviour
{
    void Awake()
    {
        //load the level in for editing
        LevelSerializationManager.LoadAndSpawnLevel();
    }

    private void SavePressed()
    {
        LevelSerializationManager.SerializeLevel();
        //send out event signal for the observer later
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
