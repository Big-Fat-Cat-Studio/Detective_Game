using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewDetection : MonoBehaviour
{
    public Transform player;
    public float maxAngle;
    public float maxRadius;
    public float heightMultiplayer = 1.5f;
    private bool isinFOV = false;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxRadius);

        Vector3 line1 = Quaternion.AngleAxis(maxAngle, transform.up)* transform.forward * maxRadius;
        Vector3 line2 = Quaternion.AngleAxis(-maxAngle, transform.up)* transform.forward * maxRadius;

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, line1);
        Gizmos.DrawRay(transform.position, line2);

        if (!isinFOV)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;
        }
        Gizmos.DrawRay(transform.position, (player.position - transform.position).normalized * maxRadius);

        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, player.forward * maxRadius);
    }


    public bool inFOV(Transform checkingObject, Transform target, float maxAngle, float maxRadius) 
    { 
        Vector3 directionBetween = (target.position - checkingObject.position).normalized; 
        directionBetween.y *= 0; 
        RaycastHit hit; 
        Debug.Log("0");
        if ( Physics.Raycast(checkingObject.position , (target.position - checkingObject.position).normalized, out hit, maxRadius)) 
        {
            Debug.Log("1");
            if (LayerMask.LayerToName(hit.transform.gameObject.layer) == "Human") 
            { 
                Debug.Log("2");
                float angle = Vector3.Angle(checkingObject.forward, directionBetween);
                 Debug.Log(angle);
                  Debug.Log(maxAngle);
                if (angle <= maxAngle) 
                { 
                    Debug.Log("3");
                    return true;
                } 
            } 
        } 
        return false;

    }
    void FixedUpdate()
    {
        isinFOV = inFOV(transform, player, maxAngle, maxRadius);
    }
}
