using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManagerScript : MonoBehaviour
{
    // on clicking the start button, the game loads the main scene
    public void StartGame()
    {
        SceneManager.LoadScene("Test Scene");
    }
    // on clicking the quit button, the game quits
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();

    }
}
