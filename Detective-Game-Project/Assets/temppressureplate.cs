using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temppressureplate : MonoBehaviour
{
    public GameObject[] toxicSprinklers;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Human" || other.gameObject.tag == "Animal")
        {
            print("getriggered");
            foreach(GameObject sprinkler in toxicSprinklers)
            {
                sprinkler.GetComponent<ToxicSprinkler>().Disable();
            }
        }
    }
}
