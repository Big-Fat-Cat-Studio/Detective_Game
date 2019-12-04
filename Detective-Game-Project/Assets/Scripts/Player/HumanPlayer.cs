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
            if (GameManager.Instance.getButtonPressForPlayer(ActivePlayer.Human, "Interact", ButtonPress.Press) && hit.gameObject.tag == Constant.TAG_INTERACT
                && hit.gameObject.GetComponent<InteractableObject>().interactableType == InteractableType.Movable)
            {
                hit.gameObject.transform.parent = gameObject.transform;
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
            
                    var objectA = gameObject.transform.GetChild(gameObject.transform.childCount-1);
                    objectA.transform.parent = null;
                
                    canPushPull = false;
                }
            }

            if (GameManager.Instance.checkIfPlayerIsActive(ActivePlayer.Human))
            {
                if (isClimbing)
                {
                    gameObject.GetComponent<Animator>().SetBool("jumping", false);
                    moveDirection = new Vector3(0.0f, GameManager.Instance.getAxisForPlayer(ActivePlayer.Human, "Vertical", AxisType.Axis),
                        GameManager.Instance.getAxisForPlayer(ActivePlayer.Human, "Vertical", AxisType.Axis) * 0.3f);
                    moveDirection = transform.TransformDirection(moveDirection);
                    moveDirection *= climbingSpeed;
                    characterController.Move(moveDirection * Time.deltaTime);
                    gameObject.GetComponent<Animator>().SetBool("climbing", true);
                }
                if (canPushPull)
                {
                    gameObject.GetComponent<Animator>().SetBool("jumping", false);
                    moveDirection = new Vector3(0.0f, 0.0f, Input.GetAxis("Vertical"));
                    moveDirection = transform.TransformDirection(moveDirection);
                    moveDirection *= movementSpeed / 1.5f;
                    gameObject.GetComponent<Animator>().SetBool("pushing", true);
                }

                if (!isClimbing && !canPushPull)
                {
                    gameObject.GetComponent<Animator>().SetBool("climbing", false);
                    gameObject.GetComponent<Animator>().SetBool("pushing", false);
                    if (characterController.isGrounded)
                    {
                        gameObject.GetComponent<Animator>().SetBool("jumping", false);
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
                        moveDirection = Vector3.ClampMagnitude(moveDirection, 1f);
                        moveDirection *= movementSpeed;
                        if (GameManager.Instance.getButtonPressForPlayer(ActivePlayer.Human, "Jump", ButtonPress.Press))
                        {
                            gameObject.GetComponent<Animator>().SetBool("jumping", true);
                            moveDirection.y = jumpHeight;
                        }
                        
                    }

                    float translationRH = GameManager.Instance.getAxisForPlayer(ActivePlayer.Human, "Mouse X", AxisType.AxisRaw) * rotationSpeed;
                    translationRH *= Time.deltaTime;
                    context.m_XAxis.Value += translationRH;
                    transform.Rotate(0, translationRH, 0);
                    if (moveDirection.x == 0 && moveDirection.z == 0 && moveDirection.y == 0 && translationRH != 0)
                    {
                        gameObject.GetComponent<Animator>().SetBool("turning", true);
                    }
                    else
                    {
                        gameObject.GetComponent<Animator>().SetBool("turning", false);
                    }
                }
            }
            else
            {
                moveDirection.x = 0.0f;
                moveDirection.z = 0.0f;
                gameObject.GetComponent<Animator>().SetFloat("forward/backward", moveDirection.z);
                gameObject.GetComponent<Animator>().SetFloat("sidewalk", moveDirection.x);
                gameObject.GetComponent<Animator>().SetBool("jumping", false);
                gameObject.GetComponent<Animator>().SetBool("climbing", false);
                gameObject.GetComponent<Animator>().SetBool("turning", false);
                gameObject.GetComponent<Animator>().SetBool("pushing", false);
                gameObject.GetComponent<Animator>().SetBool("walksideways", false);
            }
            moveDirection.y -= gravity * Time.deltaTime;
            characterController.Move(moveDirection * Time.deltaTime);
        }

    }
}
