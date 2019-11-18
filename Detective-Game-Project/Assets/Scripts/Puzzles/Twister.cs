using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twister : MonoBehaviour
{
    [SerializeField] [Tooltip("Door object to open with this twister.")]
    private GameObject DoorGO;

    [SerializeField] [Tooltip("How much to move door in Y axis/up")]
    private float OpenStep = 0.0001f;
    [SerializeField] [Tooltip("How far the twister has been spun.")]
    private int OpenPercent = 1;

    private Vector3 EulAngle;
    private Rigidbody TwisterRB;

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
            TwisterRB.constraints = RigidbodyConstraints.FreezeAll;

    }

    private void FixedUpdate()
    {
        // Lever is spun in the negative direction / lower
        if ((int)gameObject.transform.eulerAngles.y < (int)EulAngle.y)
        {
            // PingPong to make the min/max values 0-100
            OpenPercent = (int) Mathf.PingPong(--OpenPercent, 100);
            StartCoroutine(MoveDoor(OpenPercent));
        }
        // Lever is being spun in the positive direction / raise
        else if ((int)gameObject.transform.eulerAngles.y > (int)EulAngle.y)
        {
            OpenPercent = (int) Mathf.PingPong(++OpenPercent, 100);
            StartCoroutine(MoveDoor((OpenPercent)));
        }
    }

    private IEnumerator MoveDoor(int p)
    {
        while (p != 0)
        {
            DoorGO.transform.position = Vector3.Lerp(
                DoorGO.transform.position,
                new Vector3(DoorGO.transform.position.x, DoorGO.transform.position.y + (p * OpenStep), DoorGO.transform.position.z),
                Time.deltaTime);
            p--;
        }
        yield return null;
    }

}
