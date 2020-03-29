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
    public double flyForce;

    // offset towards the center of the road for cash spawning
    public double tileWidth;

    // track if the building has been delivered to or not
    bool isDelivered;

    private void Start()
    {
        // initialize variables
        isDelivered = false;

        // find the cash empty-object in the hierarchy
        spawnCashFrom = GameObject.FindGameObjectWithTag("cashLocation");
    }

    //Check if the pizza thrown collided with the house object
    //if they collided, spawn cash
    void OnTriggerEnter(Collider other)
    {
        // if the current building has not been delivered to, 
        if (!isDelivered && other.gameObject.tag == "Pizza")
        {
            // spawn the cash
            SpawnCash();

            // set delivered
            isDelivered = true;

            // update the material of the building
            GetComponent<Renderer>().material = deliveredMaterial;
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
        Vector3 pos = transform.position + (toMiddle * (float) tileWidth/2);

        // Create cash in the position above the house
        GameObject cash = Instantiate(cashPrefab, pos, Quaternion.identity, spawnCashFrom.gameObject.transform);

        // apply force towards center of road
        cash.GetComponent<Rigidbody>().AddForce(toMiddle.normalized * (float) (flyForce*10));
    }
}
