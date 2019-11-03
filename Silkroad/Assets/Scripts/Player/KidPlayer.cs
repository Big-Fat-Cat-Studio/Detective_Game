using Cinemachine;
using UnityEngine;

public class KidPlayer : MonoBehaviour
{
    public float speed = 5.0f;
    public float climbing_speed = 0.1f;
    public float rotationSpeed = 100.0f;
    public bool is_active_player;
    public bool is_climbing = false;

    public bool JumpTrigger = false;
    public float jumpForce;
    public float glide;
    Rigidbody rigidBody;

    public GameObject player_camera;
    private CinemachineFreeLook context;
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        context = player_camera.GetComponent<CinemachineFreeLook>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.is_active_player)
        {
            //print("kid is active");
            if (is_climbing)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    this.gameObject.transform.Translate(Vector3.up * climbing_speed);
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    this.gameObject.transform.Translate(Vector3.down * climbing_speed);
                }
                else
                {
                    this.gameObject.transform.Translate(new Vector3(0, 0, 0));
                }
            }
            if (!is_climbing)
            {
                if (JumpTrigger == true)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        rigidBody.AddForce(transform.up * jumpForce);
                    }
                }
                else if (rigidBody.velocity.y < 0)
                {
                    if (Input.GetKey(KeyCode.Space))
                    {
                        rigidBody.drag = glide;
                    }

                }
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    rigidBody.drag = 0;
                }

                float translationRH = Input.GetAxisRaw("Mouse X") * rotationSpeed;
                translationRH *= Time.deltaTime;
                context.m_XAxis.Value += translationRH;

                transform.Rotate(0, translationRH, 0);
            }
        }
    }

    private void FixedUpdate()
    {
        if (!is_climbing && is_active_player)
        {
            float translation = Input.GetAxis("Vertical") * speed;
            rigidBody.velocity = 
                new Vector3(transform.forward.x * translation, rigidBody.velocity.y, transform.forward.z * translation);
        }
    }
}
