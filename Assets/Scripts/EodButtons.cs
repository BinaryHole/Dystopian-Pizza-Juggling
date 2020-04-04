using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EodButtons : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame ()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void DeathCards ()
    {
        
    }

    public void Restart ()
    {
        CountScore.cashUntilWin = 10000;
        CountScore.peopleKilled = 0;
        CountScore.pizzasDelivered = 0;
        SceneManager.LoadScene("Title");
    }
}
