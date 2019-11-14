using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    [SerializeField] private Collider ObjectCollider;
    [SerializeField] private Renderer ObjectRenderer;

    [SerializeField] [Tooltip("Debug Size Collider")] private Vector3 ObjectSizeCollider;
    [SerializeField] [Tooltip("Debug Size Renderer")] private Vector3 ObjectSizeRenderer;

    private Vector3 ObjectPressedSize;



    // Start is called before the first frame update
    void Start()
    {
        ObjectSizeCollider = ObjectCollider.bounds.size;
        ObjectSizeRenderer = ObjectRenderer.bounds.size;

        ObjectPressedSize = new Vector3(0, (ObjectSizeCollider.y/2), 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnChildTriggerEnter(Collider c, GameObject g)
    {
        gameObject.transform.position -= ObjectPressedSize;

        
    }

    public void OnChildTriggerExit(Collider c, GameObject g)
    {
        gameObject.transform.position += ObjectPressedSize;
    }
}
