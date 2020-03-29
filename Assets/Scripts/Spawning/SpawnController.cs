using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    // delegate used to send spawn events to the spawner scripts (spawn roads and spawn buildigns)
    public delegate void SpawnRowDelegate(float offset, double tileSize, bool isEndOfLevel);
    public event SpawnRowDelegate spawnRow;

    // define tile characteristics for spawning
    public int tileLimit;
    public double tileSize;

    // position the last tile spawned, used when spawning new tiles to calculate the offset
    float lastTileOffset;

    // track of the current number of tile rows
    private int rowCount;

    // Start is called before the first frame update
    void Start()
    {
        // initalize rowCount
        rowCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // spawn new tiles if neccessary
        spawnNewTiles();
    }

    void spawnNewTiles()
    {
        // calculate the z-offset of the new tile
        float zOffset = (float)(lastTileOffset + tileSize);

        // spawn new tiles as needed
        if (rowCount < tileLimit)
        {
            // spawn a new tile row (road and buildings)
            spawnRow(zOffset, tileSize, false);

            // set the last tile offset to the zOffset of the new tile
            lastTileOffset = zOffset;

            // update the tile row count
            rowCount++;
        }
    }

    void despawnRoadTile(GameObject roadTile)
    {
        // destroy the road tile
        Destroy(roadTile);

        // decrease the tile row count so that a new road tile can be spawned
        rowCount -= 1;
    }
 
    private void OnCollisionEnter(Collision collision)
    {
        // check if the object is a roadTile
        if (collision.gameObject.tag == "roadTile")
        {
            // despawn the road tile
            despawnRoadTile(collision.gameObject);
        }

        // destroy the gameobject normally if it isn't a roadtile
        else
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // check if the object is a roadTile
        if (other.tag == "roadTile")
        {
            // despawn the road tile
            despawnRoadTile(other.gameObject);
        }

        // destroy the gameobject normally if it isn't a roadtile
        else
        {
            Destroy(other.gameObject);
        }
    }
}
