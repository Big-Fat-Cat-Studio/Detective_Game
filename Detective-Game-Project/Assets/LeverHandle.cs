using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverHandle : MonoBehaviour
{

    [SerializeField] private Vector3 StartAngle;
    [SerializeField] private Vector3 TargetAngle;

    [SerializeField] private Vector3 CurrentAngle;

    // Rotation should be clamped between -30 and 30
    [SerializeField] private GameObject RotationBasePivotPoint;
    [SerializeField] private GameObject RotationBaseAxis;

    // Start is called before the first frame update
    void Start()
    {
        StartAngle = new Vector3(-30, 0, 0);
        TargetAngle = new Vector3(30, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentAngle = new Vector3(Mathf.LerpAngle(StartAngle.x, TargetAngle.x, Time.deltaTime * 1), 0, 0);
        RotationBasePivotPoint.transform.eulerAngles = CurrentAngle;
    }
}
