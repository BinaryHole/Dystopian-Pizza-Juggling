using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public AudioSource kaching;
    
    // Start is called before the first frame update
    void Start()
    {
        kaching = GetComponent<AudioSource>();
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

            kaching.Play(0);

            // Adds to cash total and to todaysCash. tbh I don't know if I need "cash" still
            CountScore.cash += cashAdded;
            CountScore.todaysCash += cashAdded;
        }
    }
}
