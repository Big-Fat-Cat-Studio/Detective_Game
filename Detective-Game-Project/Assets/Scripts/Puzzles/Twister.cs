using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twister : MonoBehaviour
{

    public Vector3 EulAngle;


    private void Update()
    {
        EulAngle = gameObject.transform.eulerAngles;
    }

}
