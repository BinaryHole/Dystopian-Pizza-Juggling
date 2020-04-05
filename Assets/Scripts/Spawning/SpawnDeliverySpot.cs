using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDeliverySpot : MonoBehaviour
{
    // delivery spot prefab
    public GameObject deliverySpot;

    // delivery spot type materials
    public Material pepperoniSpotMaterial;
    public Material hawaiianSpotMaterial;
    public Material spicySpotMaterial;
    public Material successfulSpotMaterial;

    public float hawaiianProb;
    public float spicyProb;
    private float pepperoniProb;

    // Start is called before the first frame update
    void Start()
    {
        // add an event listener to the spawnDeliverySpot event
        FindObjectOfType<SpawnBuildings>().spawnDeliverySpot += spawnDeliverySpot;

        // assign probabilities
        pepperoniProb = 1 - (hawaiianProb + spicyProb);
    }

    void spawnDeliverySpot(GameObject building)
    {
        // get the delivery spots container
        GameObject container = building.transform.Find("DeliverySpots").gameObject;

        // determine the number of potential delivery spots on the building
        int deliverySpotCount = container.transform.childCount;

        // determine a random delivery spot
        int deliverySpotNumber = Random.Range(1, deliverySpotCount);

        // get the selected delivery spot
        Transform selectedDeliverySpot = container.transform.GetChild(deliverySpotNumber);

        // spawn an actual delivery spot in the selected delivery spot location
        GameObject newDeliverySpot = Instantiate(deliverySpot, selectedDeliverySpot.position, Quaternion.identity, selectedDeliverySpot);

        // determine delivery spot pizza type
        Material deliverySpotMaterial = determineDeliverySpotType();

        // change delivery spot material to match pizza type
        newDeliverySpot.GetComponent<MeshRenderer>().material = deliverySpotMaterial;
    }

    Material determineDeliverySpotType()
    {
        // layout materials as a order
        Material[] materials = {pepperoniSpotMaterial, hawaiianSpotMaterial, spicySpotMaterial};
        float[] weights = {pepperoniProb, hawaiianProb, spicyProb};

        // return a random material in the materials array using the given weights
        return materials[getRandomFromWeights(weights)];
    }

    // get a randomly selected item from a list of given weights (get a random using probabilities)
    public static int getRandomFromWeights(float[] weights)
    {
        // determine the total of all weights
        float total = 0f;
        foreach(float weight in weights)
        {
            total += weight;
        }

        // return -1 if there are no weights, or they don't add up to 1
        if (weights.Length == 0 || total != 1f)
        {
            Debug.LogError("No weights given or total weights doesn't equal 1");
            return -1;
        }

        // sum of all past weights
        float t = 0f;

        // randomly generated number between 0 and 1
        float r = Random.value;

        // loop through each weight
        for (int i = 0; i < weights.Length; i++)
        {
            // if the random number resides within the current weight, return the index
            if (r <= weights[i] + t)
            {
                return i;
            }

            // add the current weight to the sum of past weights and move on
            else
            {
                t += weights[i];
            }
        }

        Debug.LogError("Something went wrong when getting a random weight! R:" + r);
        // return -1 if something goes wrong;
        return -1;
    }
}
