using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRayTest : MonoBehaviour
{
    RaycastHit hit;

    private void Update()
    {
        Debug.DrawRay(transform.position + Vector3.up, Vector3.down, Color.red);
        if (Physics.Raycast(transform.position + Vector3.up, Vector3.down, out hit))
        {
            if (hit.collider.isTrigger)
            {
                Debug.Log(hit.collider.name);
            }
        }

    }

}
