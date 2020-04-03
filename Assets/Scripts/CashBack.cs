using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashBack : MonoBehaviour
{
    // location to organize cash in the scene hierarchy
    GameObject spawnCashFrom;

    // reference gameObjects
    public GameObject cashPrefab;
    public Material deliveredMaterial;

    // force applied to the cash after spawning to 'fly' it to the middle of the road
    public float flyForce;

    // offset towards the center of the road for cash spawning
    public double tileWidth;

    // track if the building has been delivered to or not
    bool isDelivered;

    // SFX
    AudioSource[] sounds;
    AudioSource deliverySfx;

    private void Start()
    {
        // initialize variables
        isDelivered = false;

        // find the cash empty-object in the hierarchy
        spawnCashFrom = GameObject.FindGameObjectWithTag("cashLocation");

        // Get sound
        sounds = GameObject.Find("SoundManager").GetComponents<AudioSource>();
        deliverySfx = sounds[5];
    }

    //Check if the pizza thrown collided with the house object
    //if they collided, spawn cash
    void OnTriggerEnter(Collider other)
    {
        // if the current building has not been delivered to, 
        if (!isDelivered && other.gameObject.tag == "Pizza")
        {
            deliverySfx.Play(0);
            CountScore.pizzasDelivered++;

            // spawn the cash
            SpawnCash();

            // set delivered
            isDelivered = true;

            // set the delivery spot material to successful
            GetComponent<Renderer>().material = deliveredMaterial;

            // update the delivery spot layer to IgnoreRaycast
            gameObject.layer = 2;

            // disable the collider so that pizzas can pass through
            GetComponent<Collider>().enabled = false;
        }
    }

    void SpawnCash()
    {
        Debug.Log("Cash Spawned!");

        // calulate vector towards center of road
        Vector3 atMiddle = new Vector3(0, transform.position.y, transform.position.z);

        // calculate vector heading from the building towards atMiddle
        Vector3 toMiddle = (atMiddle - transform.position).normalized;

        // calculate spawn position of the cash (to spawn on the correct side of the building)
        Vector3 pos = transform.position;

        Debug.DrawLine(gameObject.transform.position, pos.normalized, Color.black, 1.5f);

        // Create cash in the position above the house
        GameObject cash = Instantiate(cashPrefab, pos, Quaternion.identity, spawnCashFrom.gameObject.transform);

        // apply force towards center of road
        cash.GetComponent<Rigidbody>().AddForce(toMiddle.normalized * flyForce, ForceMode.Impulse);
    }
}
