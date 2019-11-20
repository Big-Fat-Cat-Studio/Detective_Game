using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScriptTest : MonoBehaviour
{
    [SerializeField] private float PlayerSpeed = 5;
    [SerializeField] private float PlayerTurnSpeed = 100;
    [SerializeField] private Rigidbody PlayerRBody;

    [SerializeField] private GameObject Camera;
    [SerializeField] private Cinemachine.CinemachineFreeLook CameraContext;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRBody = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        float translationRH = Input.GetAxisRaw("Mouse X");


        PlayerRBody.velocity = (transform.right * Movement.x * PlayerSpeed) + (transform.forward * Movement.z * PlayerSpeed);

        gameObject.transform.rotation *= Quaternion.AngleAxis(PlayerTurnSpeed * translationRH * Time.deltaTime, Vector3.up);
        transform.rotation = gameObject.transform.rotation;
        CameraContext.m_XAxis.Value += PlayerTurnSpeed * translationRH * Time.deltaTime;

    }
}
