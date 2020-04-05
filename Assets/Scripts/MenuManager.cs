using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    GameObject Win;
    GameObject Lose;
    GameObject EndOfDay;
    
    // Start is called before the first frame update
    void Start()
    {
        Win = GameObject.Find("Win");
        Lose = GameObject.Find("Lose");
        EndOfDay = GameObject.Find("EndOfDay");

        Win.SetActive(false);
        Lose.SetActive(false);

        // Show win screen
        if (CountScore.cashUntilWin <= 0)
        {
            Win.SetActive(true);
            EndOfDay.SetActive(false);
        }

        // Show lose screen
        if (CountScore.cashUntilWin >= 20000)
        {
            Lose.SetActive(true);
            EndOfDay.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
