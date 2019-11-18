using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeam : MonoBehaviour
{
    // public int points;
    // public Vector3[] vertices;
    // public Vector3 startPosition;

    // private LineRenderer lr;
    
	// void Start() {
    //     lr = GetComponent<LineRenderer>();
	// }
	
	// void Update()
    // {
	// }

    // private void SetTargetEnemy() {
    //     RaycastHit objectHit;
    //     // Shoot raycast
    //     if (Physics.Raycast(startPosition, transform.forward, out objectHit, 50)) {
    //         Debug.Log(objectHit.collider.gameObject.name);
    //     }
    //     Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
    //     Debug.DrawRay(transform.position, forward, Color.green);
    // }

    // public Vector3 direction = Vector3.forward;
    // public RaycastHit hit;
    // public float MaxDistance = 10;
    // public LayerMask layermask;

    // void Update()
    // {
    //     Ray ray = new Ray(transform.position, transform.forward);

    //     Debug.DrawRay(ray.origin, ray.direction * MaxDistance, Color.green);

    //     if(Physics.Raycast(ray, out hit, MaxDistance, layermask))
    //     {
    //         Vector3 reflectDir = Vector3.Reflect(transform.forward, hit.normal);
    //         print(reflectDir);
    //         float rot = 90 - Mathf.Atan2(reflectDir.z, reflectDir.x) * Mathf.Rad2Deg;
    //         Debug.DrawRay(hit.point, rot)
    //     }
    // }

    public int rayCount = 5;
    private LineRenderer lr;
    
	void Start() {
        lr = GetComponent<LineRenderer>();
	}

    void Update()
    {
        CastRay(transform.position, transform.forward);
    }

    void CastRay(Vector3 position, Vector3 direction)
    {
        List<Vector3> positions = new List<Vector3>();
        positions.Add(transform.position);

        for(int i = 0; i < rayCount; i++)
        {
            Ray ray = new Ray(position, direction);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 10, 1))
            {
                if(hit.collider.tag == "Reflectable")
                {
                    Debug.DrawLine(position, hit.point, Color.red);
                    position = hit.point;
                    direction = hit.normal;

                    positions.Add(hit.point);
                }
                else {
                    Debug.DrawLine(position, hit.point, Color.blue);
                    positions.Add(hit.point);
                    break;
                }
            }
            else
            {
                Debug.DrawRay(position, direction * 30, Color.blue);
                positions.Add(direction * 30);
                break;
            }
        }
        lr.SetVertexCount(positions.Count);
        lr.SetPositions(positions.ToArray());
    }
}
