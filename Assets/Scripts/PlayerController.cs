using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public int controlSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = 2;
        controlSpeed = 50;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
        rb.AddForce(movement * controlSpeed);
    }
}

//https://learn.unity.com/tutorial/movement-basics?projectId=5c514956edbc2a002069467c#5c7f8528edbc2a002053b70f move tutorial
//character will launch in the x direction and will control movement in the y (up) and z (left/right) directions