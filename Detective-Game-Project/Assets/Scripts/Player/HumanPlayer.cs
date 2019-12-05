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

        Rigidbody body;
        public GameObject umbrella;
        public bool umbrellaActiveOnStart;

        private void Start()
        {
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
                if (moveCamera)
                {
                    MoveCamera();

                    if (inputType == InputType.Keyboard || (inputType == InputType.Controller && cameraDirection.x > -0.6 && cameraDirection.x < 0.6))
                    {
                        moveCamera = false;
                    }
                }

                if (move)
                {
                    if (isClimbing)
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
                    else if (canPushPull)
                    {
                        Push();

                        gameObject.GetComponent<Animator>().SetBool("jumping", false);
                        gameObject.GetComponent<Animator>().SetBool("pushing", true);
                        move = false;
                    }
                    else if (characterController.isGrounded)
                    {
                        Move();

                        gameObject.GetComponent<Animator>().SetBool("jumping", false);
                        gameObject.GetComponent<Animator>().SetBool("climbing", false);
                        gameObject.GetComponent<Animator>().SetBool("pushing", false);
                        gameObject.GetComponent<Animator>().SetFloat("forward/backward", Mathf.Round(direction.y));
                        gameObject.GetComponent<Animator>().SetFloat("sidewalk", Mathf.Round(direction.x));
                        
                        if (Mathf.Round(direction.x) != 0)
                        {
                            gameObject.GetComponent<Animator>().SetBool("walksideways", true);
                        }
                        else
                        {
                            gameObject.GetComponent<Animator>().SetBool("walksideways", false);
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

                if (moveDirection == Vector3.zero && characterController.isGrounded)
                {
                    gameObject.GetComponent<Animator>().SetFloat("forward/backward", moveDirection.z);
                    gameObject.GetComponent<Animator>().SetFloat("sidewalk", moveDirection.x);
                    gameObject.GetComponent<Animator>().SetBool("climbing", false);
                    gameObject.GetComponent<Animator>().SetBool("jumping", false);
                    gameObject.GetComponent<Animator>().SetBool("turning", false);
                    gameObject.GetComponent<Animator>().SetBool("pushing", false);
                    gameObject.GetComponent<Animator>().SetBool("walksideways", false);
                }

                moveDirection.y -= gravity * Time.deltaTime;
                characterController.Move(moveDirection * Time.deltaTime);
            }
        }

        protected void OnSpecial()
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
