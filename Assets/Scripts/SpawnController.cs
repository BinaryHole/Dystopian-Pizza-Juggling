using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    // road prefab(s) and spawn location
    public GameObject road1;
    public GameObject spawnRoadsFrom;

    // building prefabs and spawn location
    public GameObject building1;
    public GameObject building2;
    public GameObject deliveryBuilding;
    public GameObject spawnBuildingsFrom;
    // probability of spawning a regular building
    double regularBuildingProb;
    // defined start-point for the delivery-buidling probability
    public double startingDeliveryBuildingProb;

    // code-defined delivery-building probability
    double deliveryBuildingProb;

    // track of the current number of tile rows
    private int rowCount;

    // define tile characteristics for spawning
    public int tileLimit;
    public double tileSize;

    // position the last tile spawned, used when spawning new tiles to calculate the offset
    float lastTileOffset;

    // Start is called before the first frame update
    void Start()
    {
        // initalize variables
        rowCount = 1;
        deliveryBuildingProb = startingDeliveryBuildingProb;
        regularBuildingProb = 1 - deliveryBuildingProb;
    }

    // Update is called once per frame
    void Update()
    {
        // spawn new tiles if neccessary
        spawnNewTiles();
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

    void spawnNewTiles()
    {
        // calculate the z-offset of the new tile
        float zOffset = (float)(lastTileOffset + tileSize);

        // spawn new tiles as needed
        if (rowCount < tileLimit)
        {
            // spawn a new tile row (road and buildings)
            spawnRoadTile(zOffset);
            spawnBuildingTiles(zOffset);

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

        // determine the building types of the new tiles
        GameObject type1 = determineBuildingType();
        GameObject type2 = determineBuildingType();

        // spawn both new buildings
        Instantiate(type1, pos1, Quaternion.identity, spawnBuildingsFrom.transform);
        Instantiate(type2, pos2, Quaternion.identity, spawnBuildingsFrom.transform);
    }

    // randomly determines a new building type based on the probability weights of each building type
    GameObject determineBuildingType()
    {
        // get a random number between 0-1 (inclusive)
        float rand = Random.value;

        if (rand <= regularBuildingProb)
        {
            // spawn regular building
            return building1;
        } 
        else if (rand <= regularBuildingProb+deliveryBuildingProb)
        {
            // spawn delivery building
            return deliveryBuilding;
        }

        // return building1 if something goes wrong
        return building1;
    }
}
