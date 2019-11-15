using UnityEngine;
using Cinemachine;

namespace Scripts
{
    public class HumanPlayer : MonoBehaviour
    {
        [HideInInspector]
        public bool isClimbing = false;

        private CinemachineFreeLook context;

        CharacterController characterController;
        public float movementSpeed = 3.0f;
        public float climbingSpeed = 2.0f;
        public float rotationSpeed = 100.0f;
        public float jumpHeight = 8.0f;
        public float gravity = 20f;
        private Vector3 moveDirection = Vector3.zero;


        private void Start()
        {
            context = GameManager.Instance.CameraContext.GetComponent<CinemachineFreeLook>();
            characterController = GetComponent<CharacterController>();
        }


        private void OnTriggerEnter(Collider collision)
        {
            if (collision.tag == "Ladder")
            {
                isClimbing = true;
                gravity = 0f;
            }
        }


        private void OnTriggerExit(Collider collision)
        {
            if (collision.tag == "Ladder")
            {
                gravity = 20.0f;
                isClimbing = false;
            }
        }


        private void FixedUpdate()
        {
            if (!isClimbing && GameManager.Instance.ActivePlayer == ActivePlayer.Human)
            {
                if (characterController.isGrounded)
                {
                    moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
                    moveDirection = transform.TransformDirection(moveDirection);
                    moveDirection *= movementSpeed;

                    if (Input.GetButton("Jump"))
                    {
                        moveDirection.y = jumpHeight;
                    }
                }
                moveDirection.y -= gravity * Time.deltaTime;
                characterController.Move(moveDirection * Time.deltaTime);

                float translationRH = Input.GetAxisRaw("Mouse X") * rotationSpeed;
                translationRH *= Time.deltaTime;
                context.m_XAxis.Value += translationRH;
                transform.Rotate(0, translationRH, 0);
            }


            if (isClimbing && GameManager.Instance.ActivePlayer == ActivePlayer.Human)
            {
                moveDirection = new Vector3(0.0f, Input.GetAxis("Vertical"), Input.GetAxis("Vertical") * 0.2f);
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= climbingSpeed;
                characterController.Move(moveDirection * Time.deltaTime);
            }
        }

    }
}
