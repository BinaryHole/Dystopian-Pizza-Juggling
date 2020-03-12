using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// TODO: Make the player score a variable in here, instead of on the player model. 
public class CountScore : MonoBehaviour
{
    public Text CashText;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int myCash = GameObject.Find("Player").GetComponent<Pickup>().cash;
        CashText.text = "Cash: $" + myCash;
    }

}