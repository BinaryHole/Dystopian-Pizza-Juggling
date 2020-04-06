using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoads : MonoBehaviour
{
    // road prefabs and probabilities
    public GameObject roadPrimary;
    private double roadPrimaryProb;
    public GameObject roadVariant1;
    public double roadVariant1Prob;

    // intersection road prefab and probability
    public GameObject roadIntersection;
    public float roadIntersectionProb;

    // road spawn location
    public GameObject spawnRoadsFrom;

    // Start is called before the first frame update
    void Start()
    {
        // set roadPrimary probability
        roadPrimaryProb = 1 - (roadVariant1Prob);

        // add an event listener for spawnRow
        FindObjectOfType<SpawnController>().spawnRow += spawnRoadTile;
    }

    // used to spawn a road tile at the end of the existing tiles
    void spawnRoadTile(float zOffset, double tileSize, bool isEndOfLevel)
    {
        // calculate the position of the new tile
        Vector3 newPos = new Vector3(0, 0, zOffset);

        // determine the road type
        GameObject roadObject = determineRoadType();

        // spawn the new road tile
        Instantiate(roadObject, newPos, Quaternion.identity, spawnRoadsFrom.transform);
    }

    public void spawnIntersectionRow(float zOffset, double tileSize)
    {
        // spawn the middle intersection tile
        Instantiate(roadIntersection, new Vector3(0, 0, zOffset), Quaternion.identity, spawnRoadsFrom.transform);

        // determine both road variation types
        GameObject leftRoadType = determineRoadType();
        GameObject rightRoadType = determineRoadType();

        // spawn both roads (rotated 90 degrees to be going sideways)
        Instantiate(leftRoadType, new Vector3((float) (-1 * tileSize), 0, zOffset), Quaternion.Euler(0, 90, 0), spawnRoadsFrom.transform);
        Instantiate(rightRoadType, new Vector3((float) tileSize, 0, zOffset), Quaternion.Euler(0, 90, 0), spawnRoadsFrom.transform);
    }

    GameObject determineRoadType()
    {
        // get a random number between 0-1 (inclusive)
        float rand = Random.value;

        if (rand <= roadPrimaryProb)
        {
            // spawn primary road
            return roadPrimary;
        }
        else if (rand <= roadPrimaryProb + roadVariant1Prob)
        {
            // spawn variant 1 road
            return roadVariant1;
        }

        // return primary road if something goes wrong
        return roadPrimary;
    }
}
