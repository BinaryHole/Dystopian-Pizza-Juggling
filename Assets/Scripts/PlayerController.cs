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

        // make the player face the direction of motion
        //player.transform.LookAt(movement);
        if (isLaunched)
        {
            rb.AddForce(movement * controlSpeed);
        }

        //print(isLaunched);
    }
}