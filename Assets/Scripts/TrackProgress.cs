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
        maxDistance = GameObject.Find("GameManager").GetComponent<LaunchPlayer>().maxDistance;
        distanceTravelled = GameObject.Find("GameManager").GetComponent<LaunchPlayer>().distanceTravelled;

        ProgressSlider.value = distanceTravelled;
        ProgressSlider.maxValue = maxDistance;
    }

    // Update is called once per frame
    void Update()
    {
        ProgressSlider.value = distanceTravelled;
    }
}
