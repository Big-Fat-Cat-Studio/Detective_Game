using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twister : MonoBehaviour
{
    [SerializeField] [Tooltip("Door object to open with this twister.")]
    private GameObject DoorGO;

    [SerializeField] [Tooltip("How much to move door in Y axis/up")]
    private float OpenStep = 0.001f;
    [SerializeField] [Tooltip("How far the twister has been spun.")]
    private int OpenPercent = 1;

    private Vector3 EulAngle;
    private Rigidbody TwisterRB;

    [SerializeField] private bool OpenStatus;

    private void Start()
    {
        TwisterRB = gameObject.GetComponent<Rigidbody>();
        
    }


    private void Update()
    {
        // https://docs.unity3d.com/ScriptReference/Rigidbody-constraints.html
        // Object's angles, we're interested in the Y component
        EulAngle = gameObject.transform.eulerAngles;

        if (OpenPercent > 99)
        {
            TwisterRB.constraints = RigidbodyConstraints.FreezeAll;
            OpenStatus = true;
        }

        // Once OpenStatus == true -> Open DoorGO. Put the functionality in the
        // TODO around line 61~

    }

    private void FixedUpdate()
    {
        // Lever is spun in the negative direction / lower
        if ((int)gameObject.transform.eulerAngles.y < (int)EulAngle.y)
        {
            // PingPong to make the min/max values 0-100
            OpenPercent = (int) Mathf.PingPong(--OpenPercent, 100);
            // MoveDoor(-1 * Mathf.Pow((float)OpenPercent, -1f)
        }
        // Lever is being spun in the positive direction / raise
        else if ((int)gameObject.transform.eulerAngles.y > (int)EulAngle.y)
        {
            OpenPercent = (int) Mathf.PingPong(++OpenPercent, 100);
            // MoveDoor(Mathf.Pow((float)OpenPercent, -1f)
        }
    }

    // TODO(HAMZA) // Coroutine for opening the door.

}
