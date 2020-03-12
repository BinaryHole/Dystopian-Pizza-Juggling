using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashBack : MonoBehaviour
{
    
    public Transform cashPrefab;
    public float spawnRate = 5.0f;

    //Check if the pizza thrown collided with the house object
    //if they collided, spawn cash
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pizza")
        {
            StartCoroutine("SpawnCash");
        }
            //isDelivered = true;
    }

    IEnumerator SpawnCash()
    {
        // Create cash in the position above the house
        Vector3 position = new Vector3((GameObject.FindGameObjectWithTag("House").transform.position.x), (GameObject.FindGameObjectWithTag("House").transform.position.y + 2.0f), (GameObject.FindGameObjectWithTag("House").transform.position.z + 10.0f));
        Instantiate(cashPrefab, position, Quaternion.identity);

        // Spawn a fly anywhere between 0.6 seconds to the max spawn rate (default 5). 
        yield return new WaitForSeconds(Random.Range(0.6f, spawnRate));
        if (spawnRate >= 1.2f)
        {
            spawnRate -= 0.2f;
        }


    }

}
