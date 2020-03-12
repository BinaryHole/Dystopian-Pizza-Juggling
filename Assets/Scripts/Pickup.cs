using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    // This is here for now, but should be tied to the GameManager later
    public int cash;
    
    // Start is called before the first frame update
    void Start()
    {
        cash = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("cash"))
        {
            // This should be semi-random later.
            int cashAdded = 150;
            
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            // This is where you would play a pickup sound effect
            cash += cashAdded;
        }
    }
}
