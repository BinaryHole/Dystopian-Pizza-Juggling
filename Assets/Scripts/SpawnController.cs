using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject road1;

    private int tileCount;

    public int tileLimit;
    public double tileSize;

    // Start is called before the first frame update
    void Start()
    {
        tileCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // calculate the offset


        // spawn a road tile with the distance offset

        Destroy(other.gameObject);
    }

    void spawnRoadTile()
    {
        Vector3 newPos = new Vector3(0, 0, (float) (tileCount * tileSize));
    }
}
