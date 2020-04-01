using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject gameManager;
    static public bool isDead = false;  // Used to check hospital bills in StatsManagement.cs

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {
            isDead = true;
            print("death comes to all");
            gameManager.GetComponent<LaunchPlayer>().isLanded = true;
        }
    }
}
