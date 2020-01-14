using Cinemachine;
using UnityEngine;
using System;

namespace Scripts {
    public class AnimalPlayer : Player
    {
        public ParticleSystem pissParticles;
        private bool bounce = false;
        public AudioClip bark;
        public AudioClip Poo;
        public AudioClip Pee;
        public AudioClip Eat;
        public AudioClip Boing;
        private AudioSource AudioComponent;
        
        [HideInInspector]
        public float boostTimer = 0f;
        public float pissTimer = 0f;
        public float poopTimer = 0f;
        [HideInInspector]
        public bool cannotmove = false;
        Animator animator;

        public GameObject pissPrefab;
        public GameObject poopPrefab;
        public Transform poopLocation;

        private void Start()
        {
            animator = GetComponent<Animator>();
            playerInteract = GetComponentInChildren<PlayerInteract>();
            currentPlayer = ActivePlayer.Animal;
            AudioComponent = GetComponent<AudioSource>();

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
                    if (!canPushPull) 
                    {
                        MoveCamera();
                    }

                    if (inputType == InputType.Keyboard || (inputType == InputType.Controller && cameraDirection.x > -0.6 && cameraDirection.x < 0.6) || canPushPull)
                    {
                        moveCamera = false;
                    }
                    
                }

                if (characterController.isGrounded)
                {
                    animator.SetBool("jump", false);
                }
                else
                {
                    animator.SetBool("jump", true);
                    animator.SetFloat("jumping", moveDirection.y);
                    
                }

                if (move)
                {
                    if (cannotmove)
                    {
                        moveDirection = Vector3.zero;
                        move = false;
                    }
                    else if (canPushPull)
                    {
                        Push();
                        move = false;
                    }
                    else
                    {
                        Move();
                        move = false;
                    }

                    if (characterController.isGrounded) {
                        animator.SetBool("jump", false);
                        animator.SetFloat("Walking", moveDirection.z);
                    }
                }

                if (jump)
                {
                    if (!cannotmove) 
                    {
                        Jump();
                    }
                   
                    jump = false;
                }
                abilityHandler();
            }
            else
            {
                moveDirection.x = 0.0f;
                moveDirection.z = 0.0f;
            }

            if(moveDirection.x == 0 && moveDirection.z == 0) 
            {
                animator.SetFloat("Walking", 0f);
            }

            if (bounce)
            {
                moveDirection.y = jumpHeight * 1.5f;
                bounce = false;
            }

            if (!characterController.isGrounded) 
            {
                moveDirection.y -= gravity * Time.deltaTime;
            }
            else if (moveDirection.y < -0.4f) 
            {
                moveDirection.y = -0.4f;
                animator.SetBool("jump", false);
            }

            characterController.Move(moveDirection * Time.deltaTime);
        }

        void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if(hit.gameObject.tag == "Umbrella")
            {
                bounce = true;
                AudioComponent.clip = Boing;
                AudioComponent.Play();

            }
            else
            {
                bounce = false;
            }
        }

        protected void OnSpecial()
        {
            
        }

        protected void OnSpecial2()
        {
            if (!characterController.isGrounded || abilityActive("poop") || cannotmove) return;
            if (AchievementsManager.Instance != null)
            {
                PlayerPrefs.SetInt("poop_counter", PlayerPrefs.GetInt("poop_counter", 0) + 1);
            }
            animator.SetBool("poop", true);
            cannotmove = true;
            activateAbilityTimer("poop");
            GameObject poop = Instantiate(poopPrefab);
            poop.transform.position = poopLocation.position;
            AudioComponent.clip = Poo;
            AudioComponent.Play();
        }

        protected void OnSpecial3()
        {
            if (!characterController.isGrounded || abilityActive("piss") || cannotmove) return;
            if (AchievementsManager.Instance != null)
            {
                PlayerPrefs.SetInt("piss_counter", PlayerPrefs.GetInt("piss_counter", 0) + 1);
            }
            animator.SetBool("piss", true);
            pissParticles.Play();
            cannotmove = true;
            activateAbilityTimer("piss");
            GameObject piss = Instantiate(pissPrefab);
            piss.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            piss.GetComponent<Collider>().enabled = false;
            piss.GetComponent<Collider>().enabled = true;
            AudioComponent.clip = Pee;
            AudioComponent.Play();
        }

        protected void OnSpecial4()
        {
            if (!characterController.isGrounded) return;

            GameObject rippleFx = (GameObject)Instantiate(Resources.Load("Sound_Ripple"));
            rippleFx.transform.parent = transform;
            rippleFx.transform.localPosition = new Vector3(0f, 0.06f, 0.05f);
            rippleFx.transform.localScale = new Vector3(1f,1f,1f);
            AudioComponent.clip = bark;
            AudioComponent.Play();
        }

        public void activateAbilityTimer(string type)
        {
            switch(type)
            {
                case "speedBoost":
                    AudioComponent.clip = Eat;
                    AudioComponent.Play();
                    boostTimer = 6f;
                    animator.SetBool("run", true);
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
                if (boostTimer == 0)
                {
                    animator.SetBool("run", false);
                    movementSpeed = 5f;
                } 
            }
            if (abilityActive("piss"))
            {
                pissTimer = Math.Max(0, pissTimer - Time.deltaTime);
                if (pissTimer > 12f && pissTimer < 12.6f)
                {
                    pissParticles.Stop();
                    animator.SetBool("piss", false);
                    cannotmove = false;

                } 
            }
            if (abilityActive("poop"))
            {
                poopTimer = Math.Max(0, poopTimer - Time.deltaTime);
                
                if (poopTimer > 12f && poopTimer < 12.6f)
                {
                    animator.SetBool("poop", false);
                    cannotmove = false;
                } 
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
