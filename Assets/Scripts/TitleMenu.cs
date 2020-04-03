using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    // Goto Quit
    public void GotoQuit ()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    // Goto Play

    public void GotoPlay ()
    {
        SceneManager.LoadScene("Level1");
    }
}
