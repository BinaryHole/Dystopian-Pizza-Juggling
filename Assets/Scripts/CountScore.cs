using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountScore : MonoBehaviour
{
    // Statics so they can transfer in between scenes
    // Example: CountScore.cash += 100;
    static public int cash = 0;
    static public int todaysCash = 0;
    static public int pizzasDelivered = 0;
    static public int peopleKilled = 0;
    static public int cashUntilWin = 10000;
    bool isMenu = false;
    
    public Text CashText;

    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        todaysCash = 0;

        if (sceneName != "Level1")
        {
            isMenu = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // This check is so you don't get errors every frame if you're on a menu
        if (isMenu == false)
        {
            CashText.text = "Cash: $" + todaysCash;
        }
        
    }

}