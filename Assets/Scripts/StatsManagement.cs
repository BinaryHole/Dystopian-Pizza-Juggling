using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsManagement : MonoBehaviour
{  
    public Text uEarned;
    public Text uRent;
    public Text uTaxes;
    public Text uHospital;
    public Text uProfit;
    public Text uPizza;
    public Text uPeople;
    public Text uMoney;

    // Start is called before the first frame update
    void Start()
    {
        // Set all variables
        int uEarnedAmt = CountScore.todaysCash;
        int uRentAmt = 400;
        int uTaxesAmt = Random.Range(20, 300);
        int uHospitalAmt = 0;
        int uProfitAmt = 0;
        int uPizzaAmt = CountScore.pizzasDelivered;
        int uPeopleAmt = CountScore.peopleKilled;
        int uMoneyAmt = 0;

        // Check to see if player went to the hospital
        if (Death.isDead == true)
        {
            uHospitalAmt = Random.Range(500, 1500);
            Death.isDead = false;
        }      

        uProfitAmt = Profit(uEarnedAmt, uTaxesAmt, uRentAmt, uHospitalAmt);

        // Update amount of money left until you win
        CountScore.cashUntilWin -= uProfitAmt;

        uMoneyAmt = CountScore.cashUntilWin;
        

        // Print all to fields
        uEarned.text = uEarnedAmt.ToString();
        uRent.text = "-" + uRentAmt;
        uTaxes.text = "-" + uTaxesAmt;
        uHospital.text = "-" + uHospitalAmt;
        uProfit.text = uProfitAmt.ToString();
        uPizza.text = uPizzaAmt.ToString();
        uPeople.text = uPeopleAmt.ToString();
        uMoney.text = uMoneyAmt.ToString();

        // Set counter back to 0
        CountScore.todaysCash = 0;
    }

    int Profit(int earned, int taxes, int rent, int hospital)
    {
        return earned - taxes - rent - hospital;
    }
}
