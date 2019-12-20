using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewDetectionTrigger : MonoBehaviour
{
    private ViewDetection Parent;

    // Start is called before the first frame update
    void Start()
    {
        Parent = gameObject.GetComponentInParent<ViewDetection>();
    }

    void OnTriggerEnter(Collider other)
    {
        Parent.OnChildTriggerEnter(other);
    }

    void OnTriggerExit(Collider other)
    {
        Parent.OnChildTriggerExit(other);
    }
}
