using UnityEngine;
using Cinemachine;

namespace Scripts
{
    public class HumanPlayer : MonoBehaviour
    {
        [HideInInspector]
        public bool isClimbing = false;
        [HideInInspector]
        public bool canPushPull = false;
        private CinemachineFreeLook context;
        CharacterController characterController;
        public float movementSpeed = 3.0f;
        public float climbingSpeed = 2.0f;
        public float rotationSpeed = 100.0f;
        public float jumpHeight = 8.0f;
        public float gravity = 20f;
        private Vector3 moveDirection = Vector3.zero;
        Rigidbody body;
        public GameObject umbrella;
        public bool umbrellaActiveOnStart;

        private void Start()
        {
            umbrella.transform.parent = gameObject.transform;
            umbrella.SetActive(false);
            if (GameManager.Instance.GameType == GameType.SinglePlayer || GameManager.Instance.PlayerOne == ActivePlayer.Human)
            if (GameManager.Instance.PlayerOne == ActivePlayer.Human)
            {
                context = GameManager.Instance.CameraFollow.GetComponent<CinemachineFreeLook>();
            }
            else
            {
                context = GameManager.Instance.CameraFollowP2.GetComponent<CinemachineFreeLook>();
            }
            characterController = GetComponent<CharacterController>();

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

        void OnControllerColliderHit(ControllerColliderHit hit)
        {
            body = hit.collider.attachedRigidbody;

            if (body == null)
            {
                return;
            }
            if (hit.gameObject.tag == "Movable")
            {
                
            }
            if (GameManager.Instance.getButtonPressForPlayer(ActivePlayer.Human, "Interact", ButtonPress.Press) && hit.gameObject.tag == "Movable")
            {
                canPushPull = true;
                body.gameObject.transform.Translate(moveDirection * Time.deltaTime);
            }
        }

        private void Update()
        {
            if (GameManager.Instance.checkIfPlayerIsActive(ActivePlayer.Human) && !canPushPull && !isClimbing &&
                GameManager.Instance.getButtonPressForPlayer(ActivePlayer.Human, "Special2", ButtonPress.Down))
            {
                umbrella.SetActive(!umbrella.activeSelf);
            }
        }

        private void FixedUpdate()
        {
            if (canPushPull)
            {
                if (!GameManager.Instance.getButtonPressForPlayer(ActivePlayer.Human, "Interact", ButtonPress.Press))
                {
                    canPushPull = false;
                }
            }

            if (GameManager.Instance.checkIfPlayerIsActive(ActivePlayer.Human))
            {
                if (isClimbing)
                {

                    moveDirection = new Vector3(0.0f, GameManager.Instance.getAxisForPlayer(ActivePlayer.Human, "Vertical", AxisType.Axis),
                        GameManager.Instance.getAxisForPlayer(ActivePlayer.Human, "Vertical", AxisType.Axis) * 0.3f);
                    moveDirection = transform.TransformDirection(moveDirection);
                    moveDirection *= climbingSpeed;
                    characterController.Move(moveDirection * Time.deltaTime);
                }
                if (canPushPull)
                {
                    moveDirection = new Vector3(0.0f, 0.0f, Input.GetAxis("Vertical"));
                    moveDirection = transform.TransformDirection(moveDirection);
                    moveDirection *= movementSpeed / 1.5f;
                }

                if (!isClimbing && !canPushPull)
                {

                    if (characterController.isGrounded)
                    {
                        moveDirection = new Vector3(GameManager.Instance.getAxisForPlayer(ActivePlayer.Human, "Horizontal", AxisType.Axis), 0.0f,
                            GameManager.Instance.getAxisForPlayer(ActivePlayer.Human, "Vertical", AxisType.Axis));
                        if (moveDirection.x != 0)
                        {
                            gameObject.GetComponent<Animator>().SetBool("walksideways", true);
                        }
                        else
                        {
                            gameObject.GetComponent<Animator>().SetBool("walksideways", false);
                        }
                        gameObject.GetComponent<Animator>().SetFloat("forward/backward", moveDirection.z);
                        gameObject.GetComponent<Animator>().SetFloat("sidewalk", moveDirection.x);
                        moveDirection = transform.TransformDirection(moveDirection);
                        moveDirection *= movementSpeed;
                        if (GameManager.Instance.getButtonPressForPlayer(ActivePlayer.Human, "Jump", ButtonPress.Press))
                        {
                            moveDirection.y = jumpHeight;
                        }
                        
                    }

                    float translationRH = GameManager.Instance.getAxisForPlayer(ActivePlayer.Human, "Mouse X", AxisType.AxisRaw) * rotationSpeed;
                    translationRH *= Time.deltaTime;
                    context.m_XAxis.Value += translationRH;
                    transform.Rotate(0, translationRH, 0);
                    
                }
            }
            else
            {
                moveDirection.x = 0.0f;
                moveDirection.z = 0.0f;
            }
            moveDirection.y -= gravity * Time.deltaTime;
            characterController.Move(moveDirection * Time.deltaTime);
        }

    }
}
