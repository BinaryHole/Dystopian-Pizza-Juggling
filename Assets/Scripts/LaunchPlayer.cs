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

    // Vars for audio sources, since there are multiple I use an array.
    public AudioSource[] sounds;
    public AudioSource surfMusic;
    public AudioSource kaboom;

    void Start()
    {
        isLaunched = false;
        rb = player.GetComponent<Rigidbody>();

        // Get audio sources
        sounds = GetComponents<AudioSource>();
        surfMusic = sounds[0];
        kaboom = sounds[1];

    }

    void Update()
    {
        if (!isLaunched && Input.GetKeyDown(KeyCode.Space))
        {
            isLaunched = true;
            rb.AddForce(0, 30, 0, ForceMode.Impulse); //switch to use launchvector
            //add a line of code in the camera following player code to check if isLaunched is checked

            // Now play music
            surfMusic.Play(0);
            kaboom.Play(0);
        }

        if (isLaunched)
        {
            //print("hi");
            rb.transform.position += playerSpeed;
        }
    }
}
