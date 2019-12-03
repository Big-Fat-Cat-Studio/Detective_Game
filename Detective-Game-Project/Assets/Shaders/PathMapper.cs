using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMapper : MonoBehaviour
{
    #region Private settings

    // [n-1]<-[n]->[n+1]
    private LinkedList<GameObject> TotalPath;
    private LinkedList<Dictionary<Vector3, Vector3>> PathPoints;
    private bool Init;
    private bool PointsConstructed;

    #endregion

    #region Public settings

    [Tooltip("Indicator arrows on/off.")]
    public bool ShowIndicators;
    [Tooltip("Offset for the arrow indicators.")]
    public Vector3 XOffset, YOffset, ZOffset;

    #endregion

    private void Start()
    {

        Init = true;
        ShowIndicators = true;

        TotalPath = new LinkedList<GameObject>();
        PathPoints = new LinkedList<Dictionary<Vector3, Vector3>>();

        XOffset = Vector3.left;
        YOffset = Vector3.up;
        ZOffset = Vector3.back;

        StartCoroutine(PathHandler());
    }

    private void Update()
    {
        if (TotalPath.Count > 0 && ShowIndicators)
            PointConstructor(TotalPath.First);

    }

    private void PointConstructor(LinkedListNode<GameObject> node)
    {
        // If node == last tile.
        if (node.Next == null)
            return;

        // Draw temporary path indicators
        Scripts.DrawArrow.ForDebug((node.Value.transform.position + YOffset),
            (node.Next.Value.transform.position - node.Value.transform.position).normalized, Color
            .cyan);

        PathPoints.AddLast(new Dictionary<Vector3, Vector3>()
        {
            { node.Value.transform.position + YOffset, node.Next.Value.transform.position + YOffset }
        });

        // Draw next tile's path indicators
        PointConstructor(node.Next);
        PointsConstructed = true;
        return;
    }


    private void PathConstructor(GameObject lastObj, GameObject nextObj)
    {

        // If tile.Neighbours equals 1; tile is the last tile in path.
        if (nextObj.GetComponent<NeighbourRelations>().Neighbours.Count == 1 && !Init)
            return;

        // Add correct tile to list and recurse to the next tile.
        foreach (GameObject innerOb in nextObj.GetComponent<NeighbourRelations>().Neighbours)
            // Prevent the recursion from going back by comparing the objIds
            if (innerOb.GetInstanceID() != lastObj.GetInstanceID())
            {
                // If by any chance we're initializing, set Init to false.
                // This is so our upper count==1 check doesn't trigger
                Init = false;
                TotalPath.AddLast(innerOb);
                PathConstructor(nextObj, innerOb);
                return;
            }
    }

    IEnumerator PathHandler()
    {
        // Wait 5 seconds for the neighbours to be fully initialized.
        yield return new WaitForSeconds(5);
        // gameObject == first tile
        TotalPath.AddLast(gameObject);
        PathConstructor(gameObject, gameObject);
    }


    public Material LineMaterial;

    private void OnDrawGizmos()
    {
        TempRender();
    }

    // Will be called after all regular rendering is done
    private void TempRender()
    {
        // Set transformation matrix for drawing to
        //GL.PushMatrix();
        // match our transform
        //GL.MultMatrix(transform.localToWorldMatrix);

        // Draw lines
        GL.Begin(GL.LINES);

        LineMaterial.SetPass(0);
        GL.Color(LineMaterial.color);
        // One vertex at transform position
        if (PointsConstructed)
        {
            foreach(Dictionary<Vector3, Vector3> couple in PathPoints)
            {
                foreach(KeyValuePair<Vector3, Vector3> item in couple)
                {
                    // Line [] -> []
                    GL.Vertex3(item.Key.x, item.Key.y, item.Key.z);
                    GL.Vertex3(item.Value.x, item.Value.y, item.Value.z);

                    // Line's head

                    Vector3 direction = (item.Value - item.Key).normalized;

                    Vector3 right = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 + 20.0f, 0) * new Vector3(0, 0, 1);
                    Vector3 left = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 - 20.0f, 0) * new Vector3(0, 0, 1);

                    Vector3 TotalDirectionVector = item.Key + direction;
                    Vector3 TotalRightVector = (right * 0.25f) + TotalDirectionVector;
                    Vector3 TotalLeftVector = (left * 0.25f) + TotalDirectionVector;


                    GL.Vertex3(TotalDirectionVector.x, TotalDirectionVector.y, TotalDirectionVector.z);
                    GL.Vertex3(TotalRightVector.x, TotalRightVector.y, TotalRightVector.z);

                    GL.Vertex3(TotalDirectionVector.x, TotalDirectionVector.y, TotalDirectionVector.z);
                    GL.Vertex3(TotalLeftVector.x, TotalLeftVector.y, TotalLeftVector.z);
                }
            }
        }

        GL.End();
        //GL.PopMatrix();
    }
}
