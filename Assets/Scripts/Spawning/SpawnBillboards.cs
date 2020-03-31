using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBillboards : MonoBehaviour
{
    public double billboardSpawnProb;
    public GameObject basicBillboard;
    public GameObject spawnBillboardsFrom;

    void Start()
    {
        FindObjectOfType<SpawnController>().spawnRow += spawnBillboards;
    }

    void spawnBillboards(float zOffset, double tileSize, bool isEndOfLevel)
    {
        float rand = Random.value;
        if (rand <= billboardSpawnProb)
        {
            float xPos;
            // choose left/right to spawn on
            if (Random.Range(1, 3) == 1)
            {
                // spawn on left
                xPos = -5.0f;
            }
            else
            {
                // spawn on right
                xPos = 5.0f;
            }

            // determine y height of the billboard
            float yPos = Random.Range(1.5f, 10.0f);

            // set it's position
            Vector3 newPos = new Vector3(xPos, yPos, zOffset);

            // determine the billboard type
            GameObject billboardObject = determineBillboardType();

            //determine billboard scale
            //billboardObject.transform.localScale *= Random.Range(1.0f, 2.0f);

            // spawn the new billy
            GameObject newBillboard = Instantiate(billboardObject, newPos, Quaternion.identity, spawnBillboardsFrom.transform);
            newBillboard.transform.localScale *= Random.Range(1.0f, 3.0f);
        }
    }

    GameObject determineBillboardType()
    {
        // temporary while there's only one billboard type
        return basicBillboard;
    }
}
