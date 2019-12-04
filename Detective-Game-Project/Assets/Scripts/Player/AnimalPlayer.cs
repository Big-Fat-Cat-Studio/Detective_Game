using Cinemachine;
using UnityEngine;

namespace Scripts {
    public class AnimalPlayer : Player
    {
        public float boostTimer = 0f;
        private bool bounce = false;

        private void Start()
        {
            playerInteract = GetComponentInChildren<PlayerInteract>();
            currentPlayer = ActivePlayer.Animal;

            if (GameManager.Instance.GameType == GameType.SinglePlayer || GameManager.Instance.PlayerOne == currentPlayer)
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
            if (GameManager.Instance.checkIfPlayerIsActive(currentPlayer))
            {
                if (moveCamera)
                {
                    MoveCamera();

                    //print(cameraDirection.x);
                    if (inputType == InputType.Keyboard || (inputType == InputType.Controller && cameraDirection.x > -0.6 && cameraDirection.x < 0.6))
                    {
                        moveCamera = false;
                    }
                }

                if (characterController.isGrounded && move)
                {
                    Move();
                    move = false;
                }

                if (jump)
                {
                    Jump();
                    jump = false;
                }
                speedBoostHandler();
            }
            else
            {
                moveDirection.x = 0.0f;
                moveDirection.z = 0.0f;
            }

            if (bounce)
            {
                moveDirection.y = jumpHeight * 1.5f;
                bounce = false;
            }

            moveDirection.y -= gravity * Time.deltaTime;
            characterController.Move(moveDirection * Time.deltaTime);
        }

        void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if(hit.gameObject.tag == "Umbrella")
            {
                bounce = true;
            }
            else
            {
                bounce = false;
            }
        }

        protected void OnSpecial()
        {
            GameManager.Instance.toggleVision();
        }

        public void speedBoostHandler()
        {
            if(boostTimer <= 0f)
            {
                movementSpeed = 6f;
                boostTimer = 0f;
            }
            else
            {
                movementSpeed = 12f;
                boostTimer -= Time.deltaTime;
            }
        }
    }
}
