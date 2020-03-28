using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject gameManager;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {
            print("death comes to all");
            gameManager.GetComponent<LaunchPlayer>().isLanded = true;
        }
    }
}
