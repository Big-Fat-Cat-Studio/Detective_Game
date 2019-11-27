using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts {
public class DigItem : MonoBehaviour
{
    private GameObject Item;
    private GameObject collide;
    bool diggable = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (diggable)
        {
             if (GameManager.Instance.getButtonPressForPlayer(ActivePlayer.Human, "Interact", ButtonPress.Down))
            {
                    collide.SetActive(false);
                    Instantiate(Item, collide.transform.position, collide.transform.rotation);
                    diggable = false;
            }
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Dig")
        {
            Item = collision.gameObject.GetComponent<DestroyableObject>().neededItem;
            diggable = true;
            collide = collision.gameObject;
        }
        
    }

     void OnTriggerExit(Collider collision)
    {
        
        if (collision.gameObject.tag == "Dig")
        {
            diggable = false;
            
        }
    }
}
}