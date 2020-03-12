using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject road1;
    public GameObject spawnRoadsFrom;

    public GameObject building1;
    public GameObject spawnBuildingsFrom;

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
        tileCount = 1;
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

    void spawnNewTiles()
    {
        // calculate the z-offset of the new tile
        float zOffset = (float)(lastTileOffset + tileSize);

        // spawn new tiles as needed
        if (tileCount < tileLimit)
        {
            // spawn a new tile row (road and buildings)
            spawnRoadTile(zOffset);
            spawnBuildingTiles(zOffset);

            // set the last tile offset to the zOffset of the new tile
            lastTileOffset = zOffset;

            // update the tile count
            tileCount++;
        }
    }

    void despawnRoadTile(GameObject roadTile)
    {
        // destroy the road tile
        Destroy(roadTile);

        // decrease the tile count so that a new road tile can be spawned
        tileCount -= 1;
    }

    // used to spawn a road tile at the end of the existing tiles
    void spawnRoadTile(float zOffset)
    {
        // calculate the position of the new tile
        Vector3 newPos = new Vector3(0, 0, zOffset);

        // spawn the new road tile
        Instantiate(road1, newPos, Quaternion.identity, spawnRoadsFrom.transform);
    }

    // spawns 2 building tiles on each side of the latest road tile
    void spawnBuildingTiles(float zOffset)
    {
        // calculate the positions of the new tiles
        Vector3 pos1 = new Vector3((float) (-1 * tileSize), 5, zOffset);
        Vector3 pos2 = new Vector3((float) tileSize, 5, zOffset);

        // spawn both new buildings
        Instantiate(building1, pos1, Quaternion.identity, spawnBuildingsFrom.transform);
        Instantiate(building1, pos2, Quaternion.identity, spawnBuildingsFrom.transform);
    }
}
