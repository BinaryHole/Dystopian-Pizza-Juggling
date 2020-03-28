using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnPizza : MonoBehaviour
{
    // the amount of time the pizza will exist
    public double lifespan;

    // track when the pizza was initialized
    float intTime;

    // Start is called before the first frame update
    void Start()
    {
        intTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // if the pizza has expired (passed it's lifespan)
        if ((Time.time - intTime) > lifespan)
        {
            // destroy the pizza
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // if the pizza collides with something other than the player
        if (other.tag != "Player" && other.tag != "House")
        {
            // destroy the pizza
            Destroy(gameObject);
        }
    }
}
