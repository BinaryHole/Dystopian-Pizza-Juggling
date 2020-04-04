using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EodButtons : MonoBehaviour
{
    // Ok so I'm getting all these THINGS
    
    public GameObject DeathCard;
    public GameObject EndOfDay;

    public GameObject Card1;
    public GameObject Card2;
    public GameObject Card3;
    public GameObject Card4;
    public GameObject Card5;
    public GameObject Card6;
    public GameObject Card7;
    public GameObject Card8;
    public GameObject Card9;
    public GameObject Card10;

    // Gonna use this for navigation
    int cardMax = 0;
    int whatCard = 0;

    public void Start()
    {
        DeathCard = GameObject.Find("DeathCard");
        EndOfDay = GameObject.Find("EndOfDay");

        Card1 = GameObject.Find("Card1");
        Card2 = GameObject.Find("Card2");
        Card3 = GameObject.Find("Card3");
        Card4 = GameObject.Find("Card4");
        Card5 = GameObject.Find("Card5");
        Card6 = GameObject.Find("Card6");
        Card7 = GameObject.Find("Card7");
        Card8 = GameObject.Find("Card8");
        Card9 = GameObject.Find("Card9");
        Card10 = GameObject.Find("Card10");

        // Set this whole menu false
        DeathCard.SetActive(false);
        Card1.SetActive(false);
        Card2.SetActive(false);
        Card3.SetActive(false);
        Card4.SetActive(false);
        Card5.SetActive(false);
        Card6.SetActive(false);
        Card7.SetActive(false);
        Card8.SetActive(false);
        Card9.SetActive(false);
        Card10.SetActive(false);

        // Set cardMax
        if (CountScore.peopleKilled >= 10)
        {
            cardMax = 10;
        }
        else
        {
            cardMax = CountScore.peopleKilled;
        }
    }

    public void PlayGame ()
    {
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame ()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void BackToMenu ()
    {
        EndOfDay.SetActive(true);
        DeathCard.SetActive(false);

        whatCard = 1;

    }

    public void DeathCards ()
    {
        // Starts up menu, plus a death card if the player
        // has any.
        EndOfDay.SetActive(false);
        DeathCard.SetActive(true);

        if (cardMax >= 1)
        {
            Card1.SetActive(true);
            whatCard = 1;
        }
    }

    public void Restart ()
    {
        // Reset statics and go back to main menu
        CountScore.cashUntilWin = 10000;
        CountScore.peopleKilled = 0;
        CountScore.pizzasDelivered = 0;
        SceneManager.LoadScene("Title");
    }


    public void Next()
    {
        /*
         *  Enjoy this nightmare! Basically, if you're on a card,
         *  and there is a card higher, it goes to that card. 
         *  Otherwise it goes back to 1.
         */
        switch (whatCard)
        {
            // If your on card one, and there is a next card, set that card active, this card false, and set the card index we're on to that of the next card.
            case 1:
                if (cardMax >= 2)
                {
                    Card1.SetActive(false);
                    Card2.SetActive(true);
                    whatCard = 2;
                }
                else
                {

                }
                break;

            case 2:
                if (cardMax >= 3)
                {
                    Card2.SetActive(false);
                    Card3.SetActive(true);
                    whatCard = 3;
                }
                else
                {
                    Card1.SetActive(true);
                    Card2.SetActive(false);
                    whatCard = 1;
                }
                break;

            case 3:
                if (cardMax >= 4)
                {
                    Card3.SetActive(false);
                    Card4.SetActive(true);
                    whatCard = 4;
                }
                else
                {
                    Card1.SetActive(true);
                    Card3.SetActive(false);
                    whatCard = 1;
                }
                break;

            case 4:
                if (cardMax >= 5)
                {
                    Card4.SetActive(false);
                    Card5.SetActive(true);
                    whatCard = 5;
                }
                else
                {
                    Card1.SetActive(true);
                    Card4.SetActive(false);
                    whatCard = 1;
                }
                break;

            case 5:
                if (cardMax >= 6)
                {
                    Card5.SetActive(false);
                    Card6.SetActive(true);
                    whatCard = 6;
                }
                else
                {
                    Card1.SetActive(true);
                    Card5.SetActive(false);
                    whatCard = 1;
                }
                break;

            case 6:
                if (cardMax >= 7)
                {
                    Card6.SetActive(false);
                    Card7.SetActive(true);
                    whatCard = 7;
                }
                else
                {
                    Card1.SetActive(true);
                    Card6.SetActive(false);
                    whatCard = 1;
                }
                break;

            case 7:
                if (cardMax >= 8)
                {
                    Card7.SetActive(false);
                    Card8.SetActive(true);
                    whatCard = 8;
                }
                else
                {
                    Card1.SetActive(true);
                    Card7.SetActive(false);
                    whatCard = 1;
                }
                break;

            case 8:
                if (cardMax >= 9)
                {
                    Card8.SetActive(false);
                    Card9.SetActive(true);
                    whatCard = 9;
                }
                else
                {
                    Card1.SetActive(true);
                    Card8.SetActive(false);
                    whatCard = 1;
                }
                break;

            case 9:
                if (cardMax >= 10)
                {
                    Card9.SetActive(false);
                    Card10.SetActive(true);
                    whatCard = 10;
                }
                else
                {
                    Card1.SetActive(true);
                    Card9.SetActive(false);
                    whatCard = 1;
                }
                break;

            case 10:
                if (cardMax >= 10)
                {
                    Card10.SetActive(false);
                    Card1.SetActive(true);
                    whatCard = 1;
                }
                else
                {
                    Card1.SetActive(true);
                    Card10.SetActive(false);
                    whatCard = 1;
                }
                break;
        }
    }
}
