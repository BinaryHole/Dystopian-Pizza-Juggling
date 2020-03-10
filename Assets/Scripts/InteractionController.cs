using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public GameObject pepperoniPizza;
    public GameObject hawaiianPizza;
    public GameObject spicyPizza;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // do player pizza throwing
        checkForShoot();
    }

    // Handles pizza throwing (checks if user is pressing left-mouse)
    void checkForShoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // instantiate the projectile pizza
            GameObject pizza = Instantiate(pepperoniPizza, player.transform.position, Quaternion.identity) as GameObject;

            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Vector3 direction;

            if (Physics.Raycast(cameraRay, out hit))
            {
                direction = (hit.point - pizza.transform.position).normalized;
            } else
            {
                direction = cameraRay.direction.normalized;
            }

            Debug.DrawRay(pizza.transform.position, direction*1000, Color.red, 2);
            pizza.GetComponent<Rigidbody>().AddForce(direction * 1000);
        }
    }
}
