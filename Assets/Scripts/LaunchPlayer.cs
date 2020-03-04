using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPlayer : MonoBehaviour
{
    public GameObject player;
    private Rigidbody rb;
    public GameObject mainCamera;
    public Vector3 launchVector;
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
            print("chicken");
            rb.AddForce(0, 30, 30, ForceMode.Impulse);
            //add a line of code in the camera following player code to check if isLaunched is checked
        }
    }
}
