using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public GameObject belt; // the parent belt that acts like a conveyor belt
    public Transform endpoint; // the empty gameobject child of the belt
    public float speed; // speed in which the objects move

    // Steps:
    // 1: add 2nd collider to belt object and check Is Trigger on
    // 2: Add empty gameobject and set it as child of belt
    // 3: position the empty gameobject a little bit further than the end of the belt

    void OnTriggerStay(Collider other)
    {
        other.transform.position = Vector3.MoveTowards(other.transform.position, endpoint.position, speed * Time.deltaTime);
    }
}
