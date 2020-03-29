using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndOFDay : MonoBehaviour
{
   /*
    *   TODO:
    *       on Start(): update text
    *       on click death cards: go to death cards scene
    *       on click restart: reset score and go to level
    *       on click quit: quit game
    *       
    *       Calculate net profit and save
    * 
    */

    public Text uMoney;
    public Text uEarned;
    public Text uRent;
    public Text uTaxes;
    public Text uHospital;
    public Text uProfit;
    public Text uPizza;
    public Text uPeople;

    int uMoneyAmt = 10000;        
    int uEarnedAmt = 0;        
    int uRentAmt = 0;       
    int uTaxesAmt = 0;    
    int uHospitalAmt = 0;   
    int uProfitAmt = 0;        
    int uPizzaAmt = 0;   
    int uPeopleAmt = 0;       

    
  

    // Start is called before the first frame update
    void Start()
    {
        // Get all fields
        uEarnedAmt = GameObject.Find("Player").GetComponent<Pickup>().cash;

        uRentAmt = 800;

        uTaxesAmt = Random.Range(100, 350);

        if (GameObject.Find("Player").GetComponent<Death>().isDead == 1)
        { 
            uHospitalAmt = Random.Range(500, 1000);
        }
        else
        {
            uHospitalAmt = 0;
        }
        
        uProfitAmt = getProfit();

        uMoneyAmt -= uProfitAmt; 

        uPizzaAmt = 0;

        uPeopleAmt = 0;


        // Insert fields into UI

        uMoney.text = uMoneyAmt.ToString();
        uEarned.text = uEarnedAmt.ToString();
        uRent.text = uRentAmt.ToString();
        uTaxes.text = uTaxesAmt.ToString();
        uHospital.text = uHospitalAmt.ToString();
        uProfit.text = uProfitAmt.ToString();
        uPizza.text = uPizzaAmt.ToString();
        uPeople.text = uPeopleAmt.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int getProfit()
    {
        int total = uEarnedAmt - uTaxesAmt - uRentAmt - uHospitalAmt;
        
        return total;
    }
}
