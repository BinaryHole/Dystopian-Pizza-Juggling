using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackProgress : MonoBehaviour
{
    float maxDistance;
    float distanceTravelled;

    public Slider ProgressSlider;

    // Start is called before the first frame update
    void Start()
    {
        maxDistance = GameObject.Find("GameManager").GetComponent<GameController>().maxDistance;
        distanceTravelled = GameObject.Find("GameManager").GetComponent<GameController>().distanceTravelled;

        ProgressSlider.minValue = 1;
        ProgressSlider.value = distanceTravelled;
        ProgressSlider.maxValue = maxDistance;
    }

    // Update is called once per frame
    void Update()
    {
        updateDistance();
    }

    void updateDistance()
    {
        distanceTravelled = GameObject.Find("GameManager").GetComponent<GameController>().distanceTravelled;
        ProgressSlider.value = distanceTravelled;
    }
}
