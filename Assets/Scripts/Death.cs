using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject gameManager;
    public int isDead = 0;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {
            isDead = 1;
            print("death comes to all");
            gameManager.GetComponent<LaunchPlayer>().isLanded = true;
        }
    }
}
