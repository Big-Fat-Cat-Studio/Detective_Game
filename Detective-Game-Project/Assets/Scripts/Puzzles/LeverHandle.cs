using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverHandle : MonoBehaviour
{

    [SerializeField] private Vector3 StartAngle;
    [SerializeField] private Vector3 TargetAngle;

    // Rotation should be clamped between -30 and 30
    [SerializeField] private GameObject RotationBasePivotPoint;

    // TODO(HAMZA:Change this to activeplayer!)
    [SerializeField] private GameObject CurrentPlayer;

    [SerializeField] private Renderer LeverRenderer;
    [SerializeField] private Renderer BaseRenderer;

    [SerializeField] private Material BaseColor;
    [SerializeField] private Material RangeColor;

    [SerializeField] [Tooltip("Object to manipulate")] private GameObject Manipulated;

    private Quaternion StartRotation;
    private Quaternion EndRotation;
    private bool Flipped;

    // Start is called before the first frame update
    void Start()
    {
        StartAngle  = new Vector3(-30, 0, 0);
        TargetAngle = new Vector3( 30, 0, 0);

        StartRotation = EndRotation = Quaternion.identity;
        StartRotation.eulerAngles = StartAngle;
        EndRotation.eulerAngles = TargetAngle;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if a player is near the lever
        if (Vector3.Distance(CurrentPlayer.transform.position, RotationBasePivotPoint.transform.position) <= 1.5f)
        {
            Vector3 direction = (RotationBasePivotPoint.transform.position - CurrentPlayer.transform.position).normalized;
            // If near the lever, check if the player is facing the lever -> dot => 0.85
            if (Vector3.Dot(direction, CurrentPlayer.transform.forward) >= 0.70)
            {
                // Highlight the lever TODO(HAMZA:Change colorchange to shaderchange)
                LeverRenderer.material = RangeColor;
                BaseRenderer.material = RangeColor;
                if (Input.GetKeyDown(KeyCode.X))
                {
                    // Rotate the lever && set interacted to !interacted on X
                    StartCoroutine(Rotate(2, () => { Flipped = !Flipped; Debug.Log($"Switch flipped : {Flipped}"); }));
                }
            }
        } else
        {
            // Highlight the lever TODO(HAMZA:Change colorchange to shaderchange)
            LeverRenderer.material = BaseColor;
            BaseRenderer.material = BaseColor;
        }
    }

    private IEnumerator Rotate(float time, Action cb)
    {
        while (time > 0.0f)
        {
            RotationBasePivotPoint.transform.rotation = (Flipped) ?
                Quaternion.Lerp(RotationBasePivotPoint.transform.rotation, StartRotation, Time.deltaTime) :
                Quaternion.Lerp(RotationBasePivotPoint.transform.rotation, EndRotation, Time.deltaTime);
            time -= Time.deltaTime;
            yield return null;
        }
        cb();
    }
}
