using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    /*
     *  This file does nothing except for give instructions on
     *  how to access music and sound effects.
     */

    /*******************
     *      SOUNDS     * 
     *******************
     * 
     *  [0] Surf Music
     *  [1] Ambience
     *  [2] Explosion
     *  [3] Cash Register
     *  [4] Wind
     *  [5] Splat
     *  [6] Whoosh
     */

    



    /*******************
     *      GUIDE      * 
     *******************/

    AudioSource[] sounds;

    // Follow with variables for the sounds you want.
    AudioSource surfMusic;
    AudioSource explosion;

    // Now in start, give them something to point to like:

    void Start()
    {
        sounds = GameObject.Find("SoundManager").GetComponents<AudioSource>();
        surfMusic = sounds[0];
        explosion = sounds[2];
    }

    // Now you can call a sound to play like:
    // surfMusic.Play(0);
    
}
