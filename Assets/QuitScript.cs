using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitScript : MonoBehaviour
{
    public Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        quitButton.onClick.AddListener(quit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void quit()
    {
        Application.Quit();
    }
}
