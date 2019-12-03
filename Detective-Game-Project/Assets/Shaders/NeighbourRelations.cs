using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighbourRelations : MonoBehaviour
{
    public List<GameObject> Neighbours          = new List<GameObject>();
    public List<BoxCollider> CurrentCollider    = new List<BoxCollider>();

    public static bool Flipper = true;

    // Start is called before the first frame update
    void Start()
    {
        // Map out all neigbours
        FindNeighbours();

        Flipper = false;
    }

    private void FindNeighbours()
    {
        NeighbourRelations[] tiles = FindObjectsOfType<NeighbourRelations>();

        foreach (NeighbourRelations tile in tiles)
            if (tile.gameObject.GetInstanceID() != gameObject.GetInstanceID())
                // Small loops of just two elements
                foreach (BoxCollider bc in CurrentCollider)
                    // Loop through these too in case of diagonal placement
                    foreach (BoxCollider ibc in tile.CurrentCollider)
                        if (bc.bounds.Intersects(ibc.bounds))
                            Neighbours.Add(ibc.gameObject);
    }
}
