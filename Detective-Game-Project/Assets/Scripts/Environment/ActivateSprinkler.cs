using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSprinkler : MonoBehaviour
{
    public static ActivateSprinkler instance;
    public int placed = 0;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if (placed == 5)
        {
            //destroy object blocking path
            Destroy(this);
        }
    }
}
