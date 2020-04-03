using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMessage : MonoBehaviour
{
    bool isStarted = false;
    public GameObject startText;

    
    // Start is called before the first frame update
    void Start()
    {
        startText = GameObject.Find("StartText");
    }

    // Update is called once per frame
    void Update()
    {
        if (isStarted == false && Input.GetKey("space"))
        {
            startText.SetActive(false);
            isStarted = true;
        }
    }
}
