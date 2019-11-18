using Cinemachine;
using UnityEngine;

namespace Scripts {
    public class AnimalPlayer : MonoBehaviour
    {
        private CinemachineFreeLook context;

        CharacterController characterController;
        public float movementSpeed = 6.0f;
        public float rotationSpeed = 100.0f;
        public float jumpHeight = 8.0f;
        public float gravity = 20f;
        private Vector3 moveDirection = Vector3.zero;


        private void Start()
        {
            context = GameManager.Instance.CameraContext.GetComponent<CinemachineFreeLook>();
            characterController = GetComponent<CharacterController>();
        }


        private void FixedUpdate()
        {
            if (GameManager.Instance.ActivePlayer == ActivePlayer.Animal)
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

                float translationRH = Input.GetAxisRaw("Mouse X") * rotationSpeed;
                translationRH *= Time.deltaTime;
                context.m_XAxis.Value += translationRH;
                transform.Rotate(0, translationRH, 0);
            }
            moveDirection.y -= gravity * Time.deltaTime;
            characterController.Move(moveDirection * Time.deltaTime);
        }
    }
}
