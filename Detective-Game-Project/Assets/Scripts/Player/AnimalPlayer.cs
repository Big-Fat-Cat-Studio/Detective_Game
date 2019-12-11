using Cinemachine;
using UnityEngine;
using System;

namespace Scripts {
    public class AnimalPlayer : Player
    {
        private bool bounce = false;
        
        [HideInInspector]
        public float boostTimer = 0f;
        public float pissTimer = 0f;
        public float poopTimer = 0f;

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
                    if (canPushPull)
                    {
                        Push();
                        move = false;
                    }
                    else
                    {
                        Move();
                        move = false;
                    }
                }

                if (jump)
                {
                    Jump();
                    jump = false;
                }
                abilityHandler();
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

        protected void OnSpecial2()
        {
            if (!characterController.isGrounded || abilityActive("poop")) return;

            activateAbilityTimer("poop");
            GameObject poop = (GameObject)Instantiate(Resources.Load("PoopPrefab"));
            poop.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.125f, gameObject.transform.position.z);
        }

        protected void OnSpecial3()
        {
            if (!characterController.isGrounded || abilityActive("piss")) return;

            activateAbilityTimer("piss");
            GameObject piss = (GameObject)Instantiate(Resources.Load("PissPrefab"));
            piss.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.125f, gameObject.transform.position.z);
        }

        public void activateAbilityTimer(string type)
        {
            switch(type)
            {
                case "speedBoost":
                    boostTimer = 3f;
                    movementSpeed = 10f;
                    break;
                case "piss":
                    pissTimer = 15f;
                    break;
                case "poop":
                    poopTimer = 15f;
                    break;
                default:
                    Debug.Log("default");
                    break;
            }
        }

        public void abilityHandler()
        {
            if (abilityActive("speedBoost"))
            {
                boostTimer = Math.Max(0, boostTimer - Time.deltaTime);
                if (boostTimer == 0) movementSpeed = 5f;
            }
            if (abilityActive("piss"))
            {
                pissTimer = Math.Max(0, pissTimer - Time.deltaTime);
            }
            if (abilityActive("poop"))
            {
                poopTimer = Math.Max(0, poopTimer - Time.deltaTime);
            }
        }

        public bool abilityActive(string type)
        {
            if (type == "speedBoost") return boostTimer != 0;
            if (type == "piss") return pissTimer != 0;
            if (type == "poop") return poopTimer != 0;

            return false;
        }
    }
}
