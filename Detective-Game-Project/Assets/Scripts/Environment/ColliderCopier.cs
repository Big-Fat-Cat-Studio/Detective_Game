using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCopier : MonoBehaviour
{
    public GameObject boxToCopy;

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = boxToCopy.transform.position;
        this.transform.rotation = boxToCopy.transform.rotation;
    }
}
