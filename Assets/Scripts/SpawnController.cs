using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject road1;

    // track of the current number of tiles
    private int tileCount;

    // define tile characteristics for spawning
    public int tileLimit;
    public double tileSize;

    // position the last tile spawned, used when spawning new tiles to calculate the offset
    float lastTileOffset;

    // Start is called before the first frame update
    void Start()
    {
        tileCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // spawn new tiles if neccessary
        spawnNewTiles();
    }

    private void OnTriggerEnter(Collider other)
    {
        // check if the object is a roadTile
        if (other.tag == "roadTag")
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

    void spawnNewTiles()
    {
        // spawn new tiles as needed
        if (tileCount < tileLimit)
        {
            spawnRoadTile();
        }
    }

    void despawnRoadTile(GameObject roadTile)
    {
        // destroy the road tile
        Destroy(roadTile);

        // decrease the tile count so that a new road tile can be spawned
        tileCount--;
    }

    // used to spawn a road tile at the end of the existing tiles
    void spawnRoadTile()
    {
        // calculate the z-offset of the new tile
        float zOffset = (float) (lastTileOffset + tileSize);

        // calculate the position of the new tile
        Vector3 newPos = new Vector3(0, 0, zOffset);

        // spawn the new road tile
        Instantiate(road1, newPos, Quaternion.identity);

        // set the last tile offset to the zOffset of the new tile
        lastTileOffset = zOffset;

        // update the tile count
        tileCount++;
    }
}
