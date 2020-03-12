using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPlayer : MonoBehaviour
{
    public GameObject player;
    private Rigidbody rb;
    public GameObject mainCamera;

    public Vector3 launchVector = new Vector3(0, 30, 0);
    public Vector3 playerSpeed = new Vector3(0, 0, 1);
    private bool isLaunched;

    void Start()
    {
        isLaunched = false;
        rb = player.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!isLaunched && Input.GetKeyDown(KeyCode.Space))
        {
            isLaunched = true;
            rb.AddForce(0, 30, 0, ForceMode.Impulse); //switch to use launchvector
            //add a line of code in the camera following player code to check if isLaunched is checked
        }

        if (isLaunched)
        {
            print("hi");
            rb.transform.position += playerSpeed;
        }
    }
}
