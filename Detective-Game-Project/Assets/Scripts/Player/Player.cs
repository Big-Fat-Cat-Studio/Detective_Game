using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts
{
    public abstract class Player : MonoBehaviour
    {
        protected CinemachineFreeLook context;
        protected CharacterController characterController;
        protected PlayerInteract playerInteract;

        protected Vector2 direction;
        [HideInInspector]
        public Vector2 cameraDirection = Vector2.zero;
        protected Vector3 moveDirection = Vector2.zero;
        protected bool jump;
        protected bool move;
        protected bool moveCamera;

        [HideInInspector]
        public InputType inputType;
        [HideInInspector]
        public ActivePlayer currentPlayer;
        public float movementSpeed = 3.0f;
        public float rotationSpeed = 100.0f;
        public float jumpHeight = 8.0f;
        public float gravity = 20f;
        private InputActionMap map;
        private Vector2 LookDelta;


        // Start is called before the first frame update
        void Start()
        {
            direction = Vector2.zero;
        }

        protected void MoveCamera()
        {
            float translationRH = cameraDirection.x * rotationSpeed;

            //this check will be changed laterrrr
            if (direction.x == 0 && direction.y == 0 && (translationRH > 10f || translationRH < -10f) && currentPlayer == ActivePlayer.Human)
            {
                gameObject.GetComponent<Animator>().SetBool("turning", true);
            }
            else
            {
                gameObject.GetComponent<Animator>().SetBool("turning", false);
            }

            translationRH *= Time.deltaTime;
            context.m_XAxis.Value += translationRH;
            transform.Rotate(0, translationRH, 0);

            if (direction.x != 0 || direction.y != 0)
            {
                move = true;
            }
        }

        protected void Move()
        {
            moveDirection = new Vector3(direction.x, 0, direction.y);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = Vector3.ClampMagnitude(moveDirection, 1f);
            moveDirection *= movementSpeed;
        }

        protected void Jump()
        {
            moveDirection.y = jumpHeight;
        }

        protected void OnMove(InputValue value)
        {
            if (GameManager.Instance.checkIfPlayerIsActive(currentPlayer))
            {
                direction = value.Get<Vector2>();
                move = true;
            }
        }

        protected void OnCameraMove(InputValue value)
        {
            if (GameManager.Instance.checkIfPlayerIsActive(currentPlayer))
            {
                cameraDirection = value.Get<Vector2>();
                moveCamera = true;
            }
        }

        protected void OnInteract()
        {
            if (GameManager.Instance.checkIfPlayerIsActive(currentPlayer))
            {
                playerInteract.interact();
            }
        }

        protected void OnSwap()
        {

        }

        protected void OnJump()
        {
            if (GameManager.Instance.checkIfPlayerIsActive(currentPlayer))
            {
                if (characterController.isGrounded)
                {
                    jump = true;
                }
            }
        }
    }
}