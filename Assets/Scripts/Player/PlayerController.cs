using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject player;
    public int controlSpeed;
    public int drag;
    public bool isLaunched;

    Vector3 lastPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = drag;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);

        
        if (isLaunched)
        {
            // apply player movement
            rb.AddForce(movement * controlSpeed);

            // make the player face the direction of motion
            player.transform.LookAt(transform.position + (movement + new Vector3(0, 0, 10)));
        }

        lastPos = transform.position;
    }
}