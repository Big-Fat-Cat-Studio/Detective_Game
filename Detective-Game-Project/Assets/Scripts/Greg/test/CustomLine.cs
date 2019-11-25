using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class CustomLine : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;

    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    // Start is called before the first frame update
    void Start()
    {
        MakeMeshData();
        CreateMesh();
    }

    void MakeMeshData()
    {
        // Vector3[] test = new Vector3[] { new Vector3(1, 2, 3), new Vector3(3, 2, 1) };
        // float lineWidth = .5f;

        // Vector3 normal = Vector3.Cross(test[0], test[1]);
        // Vector3 side = Vector3.Cross(test[0], test[1]-test[0]);

        // side.Normalize();

        // Vector3 a = test[0] + side * (lineWidth / 2);
        // Vector3 b = test[0] + side * (lineWidth / -2);
        // Vector3 c = test[1] + side * (lineWidth / 2);
        // Vector3 d = test[1] + side * (lineWidth / -2);

        // vertices = new Vector3[] { a, b, c, d };
        // triangles = new int[] { 0, 1, 2, 1, 3, 2};

        vertices = new Vector3[] { new Vector3(0, 0, 0), new Vector3(0, 0, 1), new Vector3(1, 0, 0), new Vector3(1, 0, 1) };
        triangles = new int[] { 0, 1, 2, 2, 1, 3 };
    }

    void CreateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 start = new Vector3(1, 2, 3);
        // Vector3 end = new Vector3(3, 2, 1);
        // float lineWidth = 5f;

        // Vector3 normal = Vector3.Cross(start, end);
        // Vector3 side = Vector3.Cross(normal, end-start);
        // side.Normalize();
        // Vector3 a = start + side * (lineWidth / 2);
        // Vector3 b = start + side * (lineWidth / -2);
        // Vector3 c = end + side * (lineWidth / 2);
        // Vector3 d = end + side * (lineWidth / -2);

        // Debug.DrawRay(start, end, Color.red);

        // Debug.DrawRay(a, b, Color.blue);
        // Debug.DrawRay(b, c, Color.blue);
        // Debug.DrawRay(c, a, Color.blue);

        // Debug.DrawRay(b, d, Color.blue);
        // Debug.DrawRay(d, c, Color.blue);
        // Debug.DrawRay(c, b, Color.blue);
    }
}
