using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBuildingVariationObjects : MonoBehaviour
{
    // Variation object prefabs
    public GameObject bench;
    public GameObject trash;
    public GameObject boardedWindow1;
    public GameObject boardedWindow2;

    // variation object probabilities
    public float benchProb;
    public float trashProb;
    public float boardedWindow1Prob;
    public float boardedWindow2Prob;

    // spawn random variation objects on a given building
    public void spawnBuildingVariationObjects(GameObject building)
    {
        // get the variation objects parent in the building transform
        Transform variationObjectsParent = building.transform.Find("Variation Objects");

        // spawn each variation object
        spawnVariationObject(variationObjectsParent.Find("Benches"), bench, benchProb);
        spawnVariationObject(variationObjectsParent.Find("Trash"), trash, trashProb);
        spawnVariationObject(variationObjectsParent.Find("BoardedWindows1"), boardedWindow1, boardedWindow1Prob);
        spawnVariationObject(variationObjectsParent.Find("BoardedWindows2"), boardedWindow2, boardedWindow2Prob);
    }

    // spawn a specific variation object on a given building in a given parent
    void spawnVariationObject(Transform parent, GameObject variationObject, float probability)
    {
        // loop through each child in the parent
        for (int i = 0; i < parent.childCount; i++)
        {
            // if a variation object should be spawned (determined randomly using probability weight)
            if (getWeightedBoolean(probability))
            {
                // debug if there is an error
                if (parent.GetChild(i) == null) { Debug.Log("Error with object: " + parent.gameObject); }

                // spawn a new variation object in the current placeholder within the parent
                Instantiate(variationObject, parent.GetChild(i));
            }
        }
    }

    // used to get a binary state (true or false) given a probability
    public bool getWeightedBoolean(float probWeight)
    {
        // get a random value between 0 and 1
        float random = Random.value;

        // return true if the random value is less than or equal to the given probability weight
        return (random <= probWeight);
    }
}
