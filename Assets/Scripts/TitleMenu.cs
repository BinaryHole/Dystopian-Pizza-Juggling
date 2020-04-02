using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    // Start music
    void Start()
    {
        
    }

    // Play button onclick
    void PlayNewGame()
    {
        SceneManager.LoadScene("Intro");
    }

    // Instructions button onclick
    void Instructions()
    {
        
    }

    // Credits button onclick
    void Credits()
    {

    }

    // Quit button onclick
    void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

}
