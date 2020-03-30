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
        uEarned.text = CountScore.cash.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
