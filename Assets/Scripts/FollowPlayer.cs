using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        // set the transform zOffset to the player's Z-offset
        transform.position = new Vector3(0, 0, player.transform.position.z);
    }
}
