using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector3 cameraOffset;


    void Update()
    {
        float playerZ = player.transform.position.z;
        transform.position = new Vector3(0, 0, playerZ) + cameraOffset;
    }
}
