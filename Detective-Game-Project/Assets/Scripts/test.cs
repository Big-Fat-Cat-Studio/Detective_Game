using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private bool isCollidedWithObj1 = false;
    private bool isCollidedWithObj2 = false;
    int stick = 0;
    GameObject stickobject = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (isCollidedWithObj1 && Input.GetKeyDown(KeyCode.C))
        // {
        //     stickobject.gameObject.transform.parent = gameObject.transform;
        //     stick += 1;
        //     Debug.Log("Stick1");
        // }
        // else if (isCollidedWithObj1 == false && Input.GetKeyDown(KeyCode.C))
        // {
            
        //     stick -= 1;
        //     Debug.Log("Stick-1");
        // }
        //  if (isCollidedWithObj2 && Input.GetKeyDown(KeyCode.C))
        // {
        //     Debug.Log("Stick2");
        //     stickobject.gameObject.transform.parent = gameObject.transform;
        //     stick += 1;
        // }
        // else if (isCollidedWithObj2 == false && Input.GetKeyDown(KeyCode.C))
        // {
            
        //     stick -= 1;
        //     Debug.Log("Stick-2");
        // }
        // if (isCollidedWithObj1 && isCollidedWithObj2 )
        // {
        //     gameObject.GetComponent<Rigidbody>().mass = 1;
        //     gameObject.GetComponent<Rigidbody>().velocity = stickobject.gameObject.GetComponent<Rigidbody>().velocity;
        // }
        // else
        // {
        //     gameObject.GetComponent<Rigidbody>().mass = 10000000000;
        // }
    }

    public void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.tag == "Kid")
    {
        isCollidedWithObj1 = true;
        stickobject = collision.gameObject;
    }
    else if (collision.gameObject.tag == "Grandpa")
    {
        isCollidedWithObj2 = true;
        stickobject = collision.gameObject;
    }
    

}

public void OnCollisionExit(Collision collision)
{
    if (collision.gameObject.tag == "Kid")
        isCollidedWithObj1 = false;
    else if (collision.gameObject.tag == "Grandpa")
        isCollidedWithObj2 = false;
}
}
