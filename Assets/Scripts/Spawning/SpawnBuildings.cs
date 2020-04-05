using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBuildings : MonoBehaviour
{
    // create spawnDeliverySpot delegate and event for spawning delivery spots
    public delegate void SpawnDeliverySpotDelegate(GameObject building);
    public event SpawnDeliverySpotDelegate spawnDeliverySpot;

    // primary building prefab and probabilites
    public GameObject buildingPrimary;
    private double buildingPrimaryProb;
    
    // building variant prefabs and probabilities
    public GameObject buildingVariant1;
    public double buildingVariant1Prob;

    // buildings spawn location
    public GameObject spawnBuildingsFrom;

    // probability of spawning a regular building
    double regularBuildingProb;

    // defined start-point for the delivery-buidling probability
    public double startingDeliveryBuildingProb;

    // code-defined delivery-building probability
    double deliveryBuildingProb;

    // Start is called before the first frame update
    void Start()
    {
        // set building type probabilites
        deliveryBuildingProb = startingDeliveryBuildingProb;
        regularBuildingProb = 1 - deliveryBuildingProb;

        // set building variant probabilities
        buildingPrimaryProb = 1 - (buildingVariant1Prob);

        // add an event listener for spawnRow
        FindObjectOfType<SpawnController>().spawnRow += spawnBuildingTiles;
    }

    // spawns 2 building tiles on each side of the latest road tile
    void spawnBuildingTiles(float zOffset, double tileSize, bool isEndOfLevel)
    {
        // spawn left building
        spawnBuilding((float)(-1 * tileSize), zOffset, isEndOfLevel);

        // spawn right building
        spawnBuilding((float)tileSize, zOffset, isEndOfLevel);
    }

    void spawnBuilding(float sideOffset, float zOffset, bool isEndOfLevel)
    {
        // calculate the position of the new building
        Vector3 position = new Vector3(sideOffset, 0, zOffset);

        // determine the building variant
        GameObject variant = determineBuildingVariant();

        // spawn the building
        GameObject building = Instantiate(variant, position, Quaternion.identity, spawnBuildingsFrom.transform);

        // determine if is right side
        bool isRightSide = sideOffset > 0;

        // mirror the building if it's on the right side
        if (isRightSide)
        {
            building.transform.localScale = new Vector3(-1, 1, 1);
        }

        // determine the building type (a delivery building or not)
        if (determineIsDeliveryBuilding())
        {
            // spawn a deliveryspot on the building
            spawnDeliverySpot(building);
        }
    }

    // randomly determines a new building type based on the probability weights of each building type
    GameObject determineBuildingVariant()
    {
        // get a random number between 0-1 (inclusive)
        float rand = Random.value;

        if (rand <= buildingPrimaryProb)
        {
            // spawn primary building
            return buildingPrimary;
        }
        else if (rand <= buildingPrimaryProb + buildingVariant1Prob)
        {
            // spawn variant1 building
            return buildingVariant1;
        }

        // return primary building if something goes wrong
        return buildingPrimary;
    }

    // randomly determines the type of a new building based on the probability weights of the buildin types
    bool determineIsDeliveryBuilding()
    {
        // get a random number between 0-1 (inclusive)
        float rand = Random.value;

        if (rand <= regularBuildingProb)
        {
            // return a regular building type
            return false;
        }
        else if (rand <= regularBuildingProb + deliveryBuildingProb)
        {
            // return a delivery buliding type
            return true;
        }

        // return regular building type if something goes wrong
        return false;
    }
}
