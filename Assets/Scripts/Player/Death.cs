using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject gameManager;
    static public bool isDead = false;  // Used to check hospital bills in StatsManagement.cs
    public GameObject DeathObject;


    void Start ()
    {
        DeathObject = GameObject.Find("DeathObject");
        DeathObject.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {
            isDead = true;
            print("death comes to all");
            DeathObject.SetActive(true);
            gameManager.GetComponent<GameController>().isLanded = true;
        }
    }
}
