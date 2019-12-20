using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateTrigger : MonoBehaviour
{
    private PressurePlate Parent;

    // Start is called before the first frame update
    void Start()
    {
        Parent = gameObject.GetComponentInParent<PressurePlate>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!("Animal Human".Contains(LayerMask.LayerToName(other.gameObject.layer)))) return;
        Parent.OnChildTriggerEnter(other, gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!("Animal Human".Contains(LayerMask.LayerToName(other.gameObject.layer)))) return;
        Parent.OnChildTriggerExit(other, gameObject);
    }
}
