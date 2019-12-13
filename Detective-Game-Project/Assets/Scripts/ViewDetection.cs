using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewDetection : MonoBehaviour
{
    public bool disabled;
    public bool detectOnlyHuman;
    public Transform Human;
    public Transform Dog;
    public float maxAngle;
    public float maxRadius;
    public float heightHuman = 1.5f;
    public float heightDog = 0.5f;
    private bool isinFOV = false;
    private bool isinFOV2 = false;
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
        Gizmos.DrawRay(transform.position, (Human.position - transform.position + Vector3.up * heightHuman).normalized * maxRadius);
        if (!isinFOV2)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;
        }
        Gizmos.DrawRay(transform.position, (Dog.position - transform.position + Vector3.up * heightDog).normalized * maxRadius);

        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, gameObject.transform.forward * maxRadius);
    }

    public bool inFOV(Transform checkingObject, Transform target, float maxAngle, float maxRadius) 
    { 
        Vector3 directionBetween = (target.position - checkingObject.position).normalized; 
        directionBetween.y *= 0; 
        RaycastHit hit; 
        
        if ( Physics.Raycast(checkingObject.position, (target.position - checkingObject.position + Vector3.up * heightHuman).normalized, out hit, maxRadius)) 
        {
            
            if (LayerMask.LayerToName(hit.transform.gameObject.layer) == "Human") 
            {
                float angle = Vector3.Angle(checkingObject.forward, directionBetween);
                if (angle <= maxAngle) 
                { 
                    
                    return true;
                } 
            } 
        } 
        return false;

    }
    public bool inFOV2(Transform checkingObject, Transform target, float maxAngle, float maxRadius) 
    { 
        Vector3 directionBetween = (target.position - checkingObject.position).normalized; 
        directionBetween.y *= 0; 
        RaycastHit hit; 
        
        if ( Physics.Raycast(checkingObject.position, (target.position - checkingObject.position + Vector3.up * heightDog).normalized, out hit, maxRadius)) 
        {
            
            if (LayerMask.LayerToName(hit.transform.gameObject.layer) == "Animal") 
            {
                float angle = Vector3.Angle(checkingObject.forward, directionBetween);
                if (angle <= maxAngle) 
                { 
                    
                    return true;
                } 
            } 
        } 
        return false;
    }

    void FixedUpdate()
    {
        if (disabled) return;

        if (detectOnlyHuman)
        {
            isinFOV = inFOV(transform, Human, maxAngle, maxRadius);
        }
        else
        {
            isinFOV = inFOV(transform, Human, maxAngle, maxRadius);
            isinFOV2 = inFOV2(transform, Dog, maxAngle, maxRadius);
        }
        
    }
}
