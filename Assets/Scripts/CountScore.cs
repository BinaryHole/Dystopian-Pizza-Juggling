using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountScore : MonoBehaviour
{
    public int cash = 0;
    public int pizzasDelivered = 0;
    public int peopleKilled = 0;
    
    public Text CashText;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CashText.text = "Cash: $" + cash;
    }

}