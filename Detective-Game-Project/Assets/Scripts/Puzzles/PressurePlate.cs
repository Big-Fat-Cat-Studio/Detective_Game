using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    [SerializeField] private Collider ObjectCollider;
    [SerializeField] private Renderer ObjectRenderer;

    [SerializeField] [Tooltip("Debug Size Collider")] private Vector3 ObjectSizeCollider;
    [SerializeField] [Tooltip("Debug Size Renderer")] private Vector3 ObjectSizeRenderer;

    [SerializeField] [Tooltip("Which object to manipulate")] private GameObject ObjectToManipulate;

    public Vector3 offset;
    public bool disableElement;

    private Vector3 ObjectPressedSize;
    private bool Pressed;
    private Vector3 defaultPosition;

    // Start is called before the first frame update
    void Start()
    {
        ObjectSizeCollider = ObjectCollider.bounds.size;
        ObjectSizeRenderer = ObjectRenderer.bounds.size;

        ObjectPressedSize = new Vector3(0, (ObjectSizeCollider.y/2), 0);
        if (ObjectToManipulate != null) defaultPosition = ObjectToManipulate.transform.position;
    }

    void Update()
    {
        if (ObjectToManipulate == null) return;
        if (!Pressed && ObjectToManipulate.transform.position == defaultPosition) return;

        ManipulateObject();
    }

    public void OnChildTriggerEnter(Collider c, GameObject g)
    {
        gameObject.transform.position -= ObjectPressedSize;
        Pressed = !Pressed;

        if (disableElement)
        {
            ObjectToManipulate.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void OnChildTriggerExit(Collider c, GameObject g)
    {
        gameObject.transform.position += ObjectPressedSize;
        Pressed = !Pressed;

        if (disableElement)
        {
            ObjectToManipulate.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void ManipulateObject()
    {
        // Do something with the object this plate is supposed to manipulate.
        Transform objTransform = ObjectToManipulate.transform;
        float step = 1f * Time.deltaTime;
        Vector3 destination = (Pressed ? defaultPosition + offset : defaultPosition);

        objTransform.position = Vector3.MoveTowards(objTransform.position, destination, step);
    }
}
