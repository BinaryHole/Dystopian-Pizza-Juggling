using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public double enemySpawnProb;
    public GameObject spawnEnemiesFrom;
    public GameObject basicEnemy;
    public bool isLaunched;

    void Start()
    {
        FindObjectOfType<SpawnController>().spawnRow += spawnEnemies;
    }

    void spawnEnemies(float zOffset, double tileSize, bool isEndOfLevel)
    {
        // determine if an enemy will spawn based on chance, then execute spawning or do nothing otherwise
        float rand = Random.value;
        if (rand <= enemySpawnProb && isLaunched)
        {
            // calculate the position of the new enemy
            float yPos = Random.Range(1.5f, 10.0f);
            float xPos = Random.Range(-5.0f, 5.0f);
            Vector3 newPos = new Vector3(xPos, yPos, zOffset);

            // determine the enemy type
            GameObject enemyObject = determineEnemyType();

            // spawn the new enemy
            Instantiate(enemyObject, newPos, Quaternion.identity, spawnEnemiesFrom.transform);
        }
    }

    GameObject determineEnemyType()
    {
        // temporary while there's only one enemy type
        return basicEnemy;
    }
}
