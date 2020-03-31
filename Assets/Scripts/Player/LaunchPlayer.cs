using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchPlayer : MonoBehaviour
{
    public GameObject player;
    private Rigidbody rb;
    public GameObject mainCamera;
    public GameObject enemies;

    public Vector3 launchVector = new Vector3(0, 30, 0);
    public double playerSpeed = 10;
    private float playerStartX;
    public float distanceTravelled;
    public float maxDistance;
    public bool isLaunched;
    public bool isLanded;

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
        // launch player when they hit space
        if (!isLaunched && Input.GetKeyDown(KeyCode.Space))
        {
            // launch the player
            launch();
        }

        if (isLaunched && !isLanded)
        {
            Vector3 motion = new Vector3(0, 0, (float)(playerSpeed / 100));

            // player moves at constant speed forward
            rb.transform.position += motion;
        }

        // end level after certain amount of time
        distanceTravelled = playerStartX + player.transform.position.z;
        if ((distanceTravelled >= maxDistance) || isLanded == true)
        {
            isLanded = true;
            rb.useGravity = true;
            player.GetComponent<PlayerController>().isLaunched = false;
            surfMusic.Stop();
            kaboom.Stop();
            SceneManager.LoadScene("EndOfDay");
        }
    }

    void launch()
    {
        isLaunched = true;
        rb.AddForce(0, 30, 0, ForceMode.Impulse); //switch to use launchvector
        playerStartX = player.transform.position.z;
                                                  //add a line of code in the camera following player code to check if isLaunched is checked

        // Now play music
        surfMusic.Play(0);
        kaboom.Play(0);

        //for updating isLaunched in other (PlayerController and SpawnEnemies) scripts
        player.GetComponent<PlayerController>().isLaunched = true;
        enemies.GetComponent<SpawnEnemies>().isLaunched = true;
    }
}
