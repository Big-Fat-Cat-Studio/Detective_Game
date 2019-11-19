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
            if (GameManager.Instance.GameType == GameType.SinglePlayer)
            {
                context = GameManager.Instance.CameraFollow.GetComponent<CinemachineFreeLook>();
            }
            else
            {
                context = GameManager.Instance.CameraFollowP2.GetComponent<CinemachineFreeLook>();
            }

            characterController = GetComponent<CharacterController>();
        }


        private void FixedUpdate()
        {
            if (GameManager.Instance.checkIfPlayerIsActive(ActivePlayer.Animal))
            {
                if (characterController.isGrounded)
                {
                    moveDirection = new Vector3(GameManager.Instance.getAxisForPlayer(ActivePlayer.Animal, "Horizontal", AxisType.Axis), 0.0f,
                       GameManager.Instance.getAxisForPlayer(ActivePlayer.Animal, "Vertical", AxisType.Axis));
                    moveDirection = transform.TransformDirection(moveDirection);
                    moveDirection *= movementSpeed;

                    if (GameManager.Instance.getButtonPressForPlayer(ActivePlayer.Animal, "Jump", ButtonPress.Press))
                    {
                        moveDirection.y = jumpHeight;
                    }
                }

                float translationRH = GameManager.Instance.getAxisForPlayer(ActivePlayer.Animal, "Camera X", AxisType.AxisRaw) * rotationSpeed;
                translationRH *= Time.deltaTime;
                context.m_XAxis.Value += translationRH;
                transform.Rotate(0, translationRH, 0);
            }
            if (GameManager.Instance.ActivePlayer != ActivePlayer.Animal)
            {
                moveDirection.x = 0.0f;
                moveDirection.z = 0.0f;
            }
            moveDirection.y -= gravity * Time.deltaTime;
            characterController.Move(moveDirection * Time.deltaTime);
        }

        void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "Jump")
        {
            Debug.Log("yeet");
            moveDirection.y = jumpHeight * 2;
        }
    }
    }
}
