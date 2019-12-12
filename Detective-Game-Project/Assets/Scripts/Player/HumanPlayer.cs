using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

namespace Scripts
{
    public class HumanPlayer : Player
    {
        [HideInInspector]
        public bool isClimbing = false;
        public float climbingSpeed = 2.0f;

        [HideInInspector]
        public bool isInPuzzle = false;

        Rigidbody body;
        public GameObject umbrella;
        public bool umbrellaActiveOnStart;
        Animator animator;

        public void handleSlow(float _jumpHeight, float _movementSpeed)
        {
            jumpHeight = _jumpHeight;
            movementSpeed = _movementSpeed;
        }

        private void Start()
        {
            animator = GetComponent<Animator>();
            playerInteract = GetComponentInChildren<PlayerInteract>();
            currentPlayer = ActivePlayer.Human;

            if (GameManager.Instance.GameType == GameType.SinglePlayer || GameManager.Instance.PlayerOne == currentPlayer)
            {
                context = GameManager.Instance.CameraFollow.GetComponent<CinemachineFreeLook>();
            }
            else
            {
                context = GameManager.Instance.CameraFollowP2.GetComponent<CinemachineFreeLook>();
            }

            characterController = GetComponent<CharacterController>();

            umbrella.transform.parent = gameObject.transform;
            umbrella.SetActive(false);
            if (umbrellaActiveOnStart)
            {
                umbrella.SetActive(true);
            }
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
            if (GameManager.Instance.checkIfPlayerIsActive(ActivePlayer.Human))
            {
                if (characterController.isGrounded)
                {
                    animator.SetBool("jumping", false);
                    animator.SetBool("climbing", false);
                }

                if (moveCamera)
                {
                    if (isInPuzzle || canPushPull)
                    {
                        moveCamera = false;
                    }

                    else
                    {
                        MoveCamera();

                        if (inputType == InputType.Keyboard || (inputType == InputType.Controller && cameraDirection.x > -0.6 && cameraDirection.x < 0.6))
                        {
                            moveCamera = false;
                        }
                    }
                }

                if (move)
                {
                    gameObject.GetComponent<Animator>().speed = 1;

                    if (isInPuzzle)
                    {
                        moveDirection = new Vector3(0, 0, 0);
                        move = true;
                    }
                    else if (canPushPull)
                    {
                        Push();
                        print("GOGOGO");
                        animator.SetFloat("forward/backward", 0);
                        animator.SetFloat("sidewalk", 0);
                        gameObject.GetComponent<Animator>().SetBool("turning", false);
                        animator.SetBool("walksideways", false);
                        animator.SetBool("jumping", false);
                        animator.SetBool("pushing", true);
                        move = false;
                        return;
                    }
                    else if (isClimbing)
                    {
                        gameObject.GetComponent<Animator>().SetBool("jumping", false);
                        moveDirection = new Vector3(0.0f, direction.y, direction.y * 0.3f);

                        moveDirection = transform.TransformDirection(moveDirection);
                        moveDirection *= climbingSpeed;
                        gameObject.GetComponent<Animator>().SetBool("climbing", true);

                        characterController.Move(moveDirection * Time.deltaTime);
                        move = false;
                        return;
                    }
                    else if (characterController.isGrounded)
                    {
                        Move();

                        animator.SetBool("jumping", false);
                        animator.SetBool("climbing", false);
                        animator.SetBool("pushing", false);
                        animator.SetFloat("forward/backward", Mathf.Round(direction.y));
                        animator.SetFloat("sidewalk", Mathf.Round(direction.x));

                        if (Mathf.Round(direction.x) != 0)
                        {
                            animator.SetBool("walksideways", true);
                        }
                        else
                        {
                            animator.SetBool("walksideways", false);
                        }
                        move = false;
                    }
                }

                if (jump)
                {
                    Jump();
                    gameObject.GetComponent<Animator>().SetBool("jumping", true);
                    jump = false;
                }

                if (moveDirection == Vector3.zero)
                {
                    animator.SetFloat("forward/backward", moveDirection.z);
                    animator.SetFloat("sidewalk", moveDirection.x);
                    if (isClimbing)
                    {
                        animator.speed = 0;
                    }
                    else
                    {
                        animator.SetBool("climbing", false);
                    }

                    if (characterController.isGrounded)
                    {
                        animator.SetBool("jumping", false);
                    }
                    animator.SetBool("turning", false);
                    animator.SetBool("pushing", false);
                    animator.SetBool("walksideways", false);
                }
                moveDirection.y -= gravity * Time.deltaTime;
                characterController.Move(moveDirection * Time.deltaTime);
            }
            else
            {
                moveDirection = Vector3.zero;
                moveDirection.y -= gravity;
                characterController.Move(moveDirection * Time.deltaTime);
                animator.SetFloat("forward/backward", 0);
                animator.SetFloat("sidewalk", 0);
                animator.SetBool("jumping", false);
                animator.SetBool("turning", false);
                animator.SetBool("pushing", false);
                animator.SetBool("walksideways", false);
            }
        }

        protected void OnSpecial1()
        {

        }

        protected void OnSpecial2()
        {
            if (GameManager.Instance.checkIfPlayerIsActive(ActivePlayer.Human))
            {
                umbrella.SetActive(!umbrella.activeSelf);

                if (umbrellaActiveOnStart)
                {
                    umbrellaActiveOnStart = false;
                }
            }
        }
    }
}
