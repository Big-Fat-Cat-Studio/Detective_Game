using Cinemachine;
using UnityEngine;

namespace Scripts {
    public class AnimalPlayer : MonoBehaviour
    {
        public float speed = 5.0f;
        public float climbingSpeed = 0.1f;
        public float rotationSpeed = 100.0f;
        [HideInInspector]
        public bool isClimbing = false;

        public float jumpForce;
        public float glide;
        Rigidbody rigidBody;

        private CinemachineFreeLook context;
        private void Start()
        {
            rigidBody = GetComponent<Rigidbody>();
            context = GameManager.Instance.CameraContext.GetComponent<CinemachineFreeLook>();
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.Instance.ActivePlayer == ActivePlayer.Animal)
            {
                if (isClimbing)
                {
                    if (Input.GetKey(KeyCode.W))
                    {
                        this.gameObject.transform.Translate(Vector3.up * climbingSpeed);
                    }
                    else if (Input.GetKey(KeyCode.S))
                    {
                        this.gameObject.transform.Translate(Vector3.down * climbingSpeed);
                    }
                    else
                    {
                        this.gameObject.transform.Translate(new Vector3(0, 0, 0));
                    }
                }
                if (!isClimbing)
                {
                    RaycastHit[] hits = Physics.RaycastAll(transform.position, Vector3.down, 0.5f);
                    bool hitFloor = false;

                    foreach(RaycastHit hit in hits)
                    {
                        if (!ReferenceEquals(hit.collider.gameObject, GameManager.Instance.Animal) &&
                            !ReferenceEquals(hit.collider.gameObject, GameManager.Instance.Human))
                        {
                            hitFloor = true;
                        }
                    }

                    if (hitFloor)
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
            if (!isClimbing && GameManager.Instance.ActivePlayer == ActivePlayer.Animal)
            {
                float translation = Input.GetAxis("Vertical") * speed;
                rigidBody.velocity =
                    new Vector3(transform.forward.x * translation, rigidBody.velocity.y, transform.forward.z * translation);
            }
        }
    }
}
