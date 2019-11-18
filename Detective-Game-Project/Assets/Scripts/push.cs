using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class push : MonoBehaviour
{
    // Start is called before the first frame update
    bool stick = false;
    private GameObject stickobject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stick)
        {
            stickobject.gameObject.GetComponent<Rigidbody>().velocity = gameObject.GetComponent<Rigidbody>().velocity;
        }
    }

    void OnCollisionStay(Collision collision) {
        if (collision.gameObject.tag == "Stick")
        {
            if (Input.GetKeyDown(KeyCode.C) && stick == false)
            {
                Debug.Log("failed");
                stick = true;
                stickobject = collision.gameObject;
                gameObject.transform.parent = collision.gameObject.transform;

                
            }
             if (Input.GetKeyDown(KeyCode.C) && stick == true)
            {
                gameObject.transform.parent = null;
            }
        }
         
    }
}
