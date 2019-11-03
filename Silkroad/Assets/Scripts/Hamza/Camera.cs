using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [Header("Camera Properties")]
    public float DistanceUp;
    public float minDistance;
    public float maxDistance = 2;
    public float smooth = 4.0f;
    public float rotateAround = 70f;

    public Transform target;

    [Header("Map coordinate script")]
    public float cameraHeight = 35f;
    public float cameraPan;
    public float camRotateSpeed = 180f;

    Vector3 camPosition;
    Vector3 camMask;

    public LayerMask CamOcclusion;

    private float HorizontalAxis;
    private float VerticalAxis;
    private float DistanceAway;

    void Start()
    {
        rotateAround = target.eulerAngles.y - 45f;
    }

    void FixedUpdate()
    {
        if (target == null)
        {
            return;
        }

        HorizontalAxis = Input.GetAxisRaw("Mouse X");
        VerticalAxis = Input.GetAxisRaw("Mouse Y");


        Vector3 targetOffset = new Vector3(target.position.x, (target.position.y + 2f), target.position.z);
        Quaternion rotation = Quaternion.Euler(cameraHeight, rotateAround, cameraPan);
        Vector3 vectorMask = Vector3.one;
        Vector3 rotateVector = rotation * vectorMask;

        camPosition = targetOffset + Vector3.up * DistanceUp - rotateVector * DistanceAway;
        camMask = targetOffset + Vector3.up * DistanceUp - rotateVector * DistanceAway;

        OccludeRay(ref targetOffset);
        SmoothCamMethod();

        transform.LookAt(target);


        if (rotateAround > 360)
        {
            rotateAround = 0f;
        }
        else if (rotateAround < 0f)
        {
            rotateAround = (rotateAround + 360f);
        }

        rotateAround += (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) ?
            Input.GetAxis("Horizontal") * 150f * Time.deltaTime : HorizontalAxis * camRotateSpeed * Time.deltaTime;

        DistanceAway = Mathf.Clamp(DistanceAway += VerticalAxis, minDistance, maxDistance);
    }

    void SmoothCamMethod()
    {
        smooth = 4f;
        transform.position = Vector3.Lerp(transform.position, camPosition, Time.deltaTime * smooth);
    }

    void OccludeRay(ref Vector3 targetFollow)
    {
        RaycastHit wallHit = new RaycastHit();
        if (Physics.Linecast(targetFollow, camMask, out wallHit, CamOcclusion))
        {
            smooth = 10f;
            camPosition = new Vector3(wallHit.point.x + wallHit.normal.x * 0.5f, camPosition.y, wallHit.point.z + wallHit.normal.z * 0.5f);
        }
    }
}
