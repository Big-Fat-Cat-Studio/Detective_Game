using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigItem : MonoBehaviour
{
    private bool collidewithdog = false;
    public GameObject Item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && collidewithdog)
            {
                gameObject.SetActive(false);
                Instantiate(Item, gameObject.transform.position, gameObject.transform.rotation);
            }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Kid")
        {
            collidewithdog = true; 
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Kid")
        {
            collidewithdog = false; 
        }
    }
}
