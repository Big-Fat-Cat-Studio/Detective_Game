using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigItem : MonoBehaviour
{
    public GameObject Item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay(Collision collision)
    {
        
        if (collision.gameObject.tag == "Kid")
        {
            
            if (Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("ouch");
                gameObject.SetActive(false);
                Instantiate(Item, gameObject.transform.position, gameObject.transform.rotation);
            }
            
        }
    }
}
