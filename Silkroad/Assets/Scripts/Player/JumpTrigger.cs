using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    List<string> collidedObjects = new List<string>();

    void OnTriggerStay(Collider other)
    {
        if (!collidedObjects.Contains(other.gameObject.name))
        {
            collidedObjects.Add(other.gameObject.name);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!collidedObjects.Contains(other.gameObject.name))
        {
            collidedObjects.Add(other.gameObject.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        collidedObjects.Remove(other.gameObject.name);
    }

    void Update()
    {
        var numberOfColliders = collidedObjects.Count;
        if (numberOfColliders > 1)
        {
            GetComponentInParent<KidPlayer>().JumpTrigger = true;
        }
        else
        {
            GetComponentInParent<KidPlayer>().JumpTrigger = false;
        }
    }
}
