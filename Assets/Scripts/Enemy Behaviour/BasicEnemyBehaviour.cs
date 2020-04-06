using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyBehaviour : MonoBehaviour
{
    public Transform playerTransform;
    public Rigidbody rb;

    // speed at which the enemy will zoom down the map
    public float travelSpeed;

    // speed at which the enemy will move to follow the player
    public float followSpeed;
    public float minFollowDistance;

    AudioSource[] sounds;
    AudioSource explosion;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();

        // get enemy movin
        rb.AddForce(0, 0, -travelSpeed, ForceMode.Impulse);

        // explosion for booming enemies
        sounds = GameObject.Find("SoundManager").GetComponents<AudioSource>();
        explosion = sounds[2];
    }

    void Update()
    {
        // temporarily disabled until i get this working
        //followPlayer();
    }

    void followPlayer()
    {

        // old method which results in very jiggly enemies
        /*
        Vector3 movement = new Vector3(0, 0, 0);

        // decide whether to move left or right to follow player
        if (playerTransform.position.x > rb.transform.position.x)
        {
            movement.x = 1;
        }
        else
        {
            movement.x = -1;
        }

        // decide whether to move up or down to follow player
        if (playerTransform.position.y > rb.transform.position.y)
        {
            movement.y = 1;
        }
        else
        {
            movement.y = -1;
        }

        rb.AddForce(movement * followSpeed);
        */

        Vector3 offset = playerTransform.position - rb.transform.position;
        Vector3 movement = new Vector3((float)Mathf.Sqrt(offset.x), (float)Mathf.Sqrt(offset.y), 0);
        //Vector3.Normalize(movement);
        rb.AddForce(movement * followSpeed);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Pizza")
        {
            CountScore.peopleKilled++;
            rb.useGravity = true;
            explosion.Play(0);
        }
    }

}
