using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountScore : MonoBehaviour
{
    static public int cash = 0;
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

        if (sceneName != "Level1")
        {
            isMenu = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isMenu == false)
        {
            CashText.text = "Cash: $" + cash;
        }
        
    }

}