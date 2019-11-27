using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct RayHit
{
    public string type;
    public Vector3 hitPosition;
    public Vector3 hitDirection;
    
    public RayHit(string _type, Vector3 _hitPosition, Vector3 _hitDirection)
    {
        type = _type;
        hitPosition = _hitPosition;
        hitDirection = _hitDirection;
    }
}

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Laser : MonoBehaviour
{
    Mesh mesh;
    public List<Vector3> vertices;
    public List<Vector3> allVertices;
    List<int> triangles;

    public float THICCness;

    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    void Update()
    {
        InitializeLaser(transform.position, transform.forward);

        if(allVertices.Count % 8 != 0 || allVertices.Count <= 0) return;

        MakeCubes();
        UpdateMesh();
    }

    void MakeCubes()
    {
        vertices = new List<Vector3>();
        triangles = new List<int>();
        int cubeCount = allVertices.Count / 8;

        for(int i = 0; i < cubeCount; i++)
        {
            MakeCube(i);
        }
    }

    void MakeCube(int cubeIndex)
    {
        for(int i = 0; i < 6; i++)
        {
            MakeFace(i, cubeIndex);
        }
    }

    void MakeFace(int dir, int cubeIndex)
    {
        vertices.AddRange(faceVertices(dir, cubeIndex));
        int vCount = vertices.Count;

        triangles.Add(vCount - 4);
        triangles.Add(vCount - 4 + 1);
        triangles.Add(vCount - 4 + 2);
        triangles.Add(vCount - 4);
        triangles.Add(vCount - 4 + 2);
        triangles.Add(vCount - 4 + 3);
    }

    Vector3[] faceVertices(int dir, int cubeIndex)
    {
        int[][] faceTriangles =  {
            new int[] { 0, 1, 2, 3 },
            new int[] { 5, 0, 3, 6 },
            new int[] { 4, 5, 6, 7 },
            new int[] { 1, 4, 7, 2 },
            new int[] { 5, 4, 1, 0 },
            new int[] { 3, 2, 7, 6 }
        };

        Vector3[] fv = new Vector3[4];
        for(int i = 0; i < fv.Length; i++)
        {
            fv[i] = (allVertices[faceTriangles[dir][i] + (8 * cubeIndex)]);
        }
        return fv;
    }

    void InitializeLaser(Vector3 position, Vector3 direction)
    {
        //reset vertices and trianges
        allVertices = new List<Vector3>();

        //set unique position and direction for initial raycast
        Vector3 position1 = position + (transform.TransformDirection(-Vector3.right) * 0.1f) + (transform.TransformDirection(Vector3.up) * 0.1f);
        Vector3 direction1 = direction;

        Vector3 position2 = position + (transform.TransformDirection(Vector3.right) * 0.1f) + (transform.TransformDirection(Vector3.up) * 0.1f);
        Vector3 direction2 = direction;

        Vector3 position3 = position + (transform.TransformDirection(Vector3.right) * 0.1f) + (transform.TransformDirection(-Vector3.up) * 0.1f);
        Vector3 direction3 = direction;

        Vector3 position4 = position + (transform.TransformDirection(-Vector3.right) * 0.1f) + (transform.TransformDirection(-Vector3.up) * 0.1f);
        Vector3 direction4 = direction;

        for(int i = 0; i < 30; i++)
        {
            Vector3[] tempArray = new Vector3[8];
            bool non_reflectable = false;

            for(int j = 0; j < 4; j++)
            {
                RayHit result;

                if(j == 0)
                {
                    result = CastRay(position1, direction1);

                    tempArray[4] = transform.InverseTransformPoint(position1);
                    tempArray[1] = transform.InverseTransformPoint(result.hitPosition);

                    position1 = result.hitPosition;
                    direction1 = result.hitDirection;
                }
                else if (j == 1)
                {
                    result = CastRay(position2, direction2);
                    
                    tempArray[5] = transform.InverseTransformPoint(position2);
                    tempArray[0] = transform.InverseTransformPoint(result.hitPosition);

                    position2 = result.hitPosition;
                    direction2 = result.hitDirection;
                }
                else if (j == 2)
                {
                    result = CastRay(position3, direction3);
                    
                    tempArray[6] = transform.InverseTransformPoint(position3);
                    tempArray[3] = transform.InverseTransformPoint(result.hitPosition);

                    position3 = result.hitPosition;
                    direction3 = result.hitDirection;
                }
                else 
                {
                    result = CastRay(position4, direction4);
                    
                    tempArray[7] = transform.InverseTransformPoint(position4);
                    tempArray[2] = transform.InverseTransformPoint(result.hitPosition);

                    position4 = result.hitPosition;
                    direction4 = result.hitDirection;
                }
                if(result.type == "none" || result.type == "normal") non_reflectable = true;
            }

            allVertices.AddRange(tempArray);
            if(non_reflectable) break;
        }
    }

    RayHit CastRay(Vector3 position, Vector3 direction)
    {
        Ray ray = new Ray(position, direction);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 30, 1))
        {
            if(hit.collider.tag == "Reflectable")
            {
                Debug.DrawLine(position, hit.point, Color.red);
                return new RayHit("reflect", hit.point, Vector3.Reflect(direction, hit.normal));
            }
            else
            {
                Debug.DrawLine(position, hit.point, Color.red);
                return new RayHit("normal", hit.point, hit.point);
            }
        }
        else
        {
            Debug.DrawRay(position, direction * 30, Color.blue);
            return new RayHit("none", position + direction * 30, position);
        }
    }

    void UpdateMesh()
    {
        mesh.Clear();
        
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();
    }
}
