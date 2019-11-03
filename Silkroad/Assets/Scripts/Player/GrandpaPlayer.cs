using UnityEngine;
using Cinemachine;

public class GrandpaPlayer : MonoBehaviour
{
    public float speed = 2.0f;
    public float rotationSpeed = 100.0f;
    public bool is_active_player;
    Rigidbody rigidBody;

    public GameObject player_camera;
    private CinemachineFreeLook context;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        context = player_camera.GetComponent<CinemachineFreeLook>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(is_active_player)
        {
            //print("grandpa is active");


            float translationRH = Input.GetAxisRaw("Mouse X") * rotationSpeed;
            translationRH *= Time.deltaTime;
            context.m_XAxis.Value += translationRH;

            transform.Rotate(0, translationRH, 0);
        }
    }

    private void FixedUpdate()
    {
        if (is_active_player)
        {
            float translation = Input.GetAxis("Vertical") * speed;
            rigidBody.velocity =
                new Vector3(transform.forward.x * translation, rigidBody.velocity.y, transform.forward.z * translation);
        }
    }
}
