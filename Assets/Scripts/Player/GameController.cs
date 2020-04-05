using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject player;
    private Rigidbody rb;
    public GameObject mainCamera;
    public GameObject enemies;
    public GameObject EndObject;

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

        EndObject = GameObject.Find("EndObject");
        EndObject.SetActive(false);

        // Get audio sources
        sounds = GameObject.Find("SoundManager").GetComponents<AudioSource>();
        surfMusic = sounds[0];
        kaboom = sounds[2];
    }

    private void FixedUpdate()
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
            player.GetComponent<PlayerMovementController>().isLaunched = false;

            StartCoroutine("FadeOut");
            kaboom.Stop();

            if (distanceTravelled >= maxDistance)
            {
                EndObject.SetActive(true);
            }

            StartCoroutine("LoadNextScene");
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
        player.GetComponent<PlayerMovementController>().isLaunched = true;
        enemies.GetComponent<SpawnEnemies>().isLaunched = true;
    }

    // Short delay before switching scenes
    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene("EndOfDay");
    }

    // Godspeed boris 1998 o7 https://forum.unity.com/threads/fade-out-audio-source.335031/
    // This wil fade music, Boris1998 provided it on the unity forums for everyone
    IEnumerator FadeOut()
    {
        float startVolume = surfMusic.volume;

        while (surfMusic.volume > 0)
        {
            surfMusic.volume -= startVolume * Time.deltaTime / 10;

            yield return null;
        }

        surfMusic.Stop();
        surfMusic.volume = startVolume;
    }
}
