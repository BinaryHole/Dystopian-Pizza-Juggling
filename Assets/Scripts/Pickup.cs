using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("cash"))
        {
            int cashAdded = Random.Range(100, 300);
            
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);

            // This is where you would play a pickup sound effect

            
            // Adds to cash total and to todaysCash. tbh I don't know if I need "cash" still
            CountScore.cash += cashAdded;
            CountScore.todaysCash += cashAdded;
        }
    }
}
