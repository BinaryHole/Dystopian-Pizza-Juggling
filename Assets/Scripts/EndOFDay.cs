using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndOFDay : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("Level1");
    }
       
    public void QuitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

}