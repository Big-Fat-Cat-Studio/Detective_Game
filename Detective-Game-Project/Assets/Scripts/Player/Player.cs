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
        [HideInInspector]
        public Vector3 moveDirection = Vector2.zero;
        protected bool jump;
        [HideInInspector]
        public bool move;
        protected bool moveCamera;
        [HideInInspector]
        public bool canPushPull = false;

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
        private bool released;
        public GameObject CameraFollow;

        public GameObject InGameMenu;
        public GameObject[] cutsceneTriggers;

        // Start is called before the first frame update
        void Start()
        {
            direction = Vector2.zero;
        }

        protected void MoveCamera()
        {
            float translationRH = cameraDirection.x * rotationSpeed;

            if (moveDirection.x == 0 && moveDirection.z == 0)
            {
                // CameraFollow.GetComponent<CinemachineFreeLook>().m_RecenterToTargetHeading = new AxisState.Recentering(false, 0, .5f);
                translationRH *= Time.deltaTime;
                context.m_XAxis.Value += translationRH;
            }
            else
            {
                // CameraFollow.GetComponent<CinemachineFreeLook>().m_RecenterToTargetHeading = new AxisState.Recentering(true, 0, .5f); // rotate camera behind player

                //this check will be changed laterrrr
                if (currentPlayer == ActivePlayer.Human)
                {
                    if (direction.x == 0 && direction.y == 0 && (translationRH > 10f || translationRH < -10f))
                    {
                        gameObject.GetComponent<Animator>().SetBool("turning", true);
                    }
                    else
                    {
                        gameObject.GetComponent<Animator>().SetBool("turning", false);
                    }
                }
            }

            translationRH *= Time.deltaTime;
            context.m_XAxis.Value += translationRH;
            transform.Rotate(0, translationRH, 0);

            if (direction.x != 0 || direction.y != 0)
            {
                move = true;
            }
        }

        protected void Push()
        {
            moveDirection = new Vector3(0.0f, 0.0f, direction.y);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= movementSpeed / 1.5f;
        }

        protected void Move()
        {
            float currentDirection = moveDirection.y;

            transform.localRotation = Quaternion.Euler(0, context.m_XAxis.Value, 0);
            moveDirection.x = direction.x;
            moveDirection.y = 0;
            moveDirection.z = direction.y;
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = Vector3.ClampMagnitude(moveDirection, 1f);
            moveDirection *= movementSpeed;
            if (this is AnimalPlayer)
            {
                print("x: " + direction.x + " - y: " + direction.y );
                if ((direction.x > 0.5 && direction.x <  0.9) && (direction.y > 0.5 && direction.y < 0.9) || (direction.x < -0.5 && direction.x > -0.9) && (direction.y < -0.5 && direction.y > -0.9)) 
                {
                    this.transform.Rotate(0,45,0);
                }
                else if ((direction.x < -0.5 && direction.x >  -0.9) && (direction.y > 0.5 && direction.y < 0.9) || (direction.x > 0.5 && direction.x < 0.9) && (direction.y < -0.5 && direction.y > -0.9)) 
                {
                    this.transform.Rotate(0,-45,0);
                }
                else if (Mathf.Round(direction.x) == 1 && (direction.y > -0.5 && direction.y < 0.5))
                {
                    this.transform.Rotate(0,90,0);
                }
                else if (Mathf.Round(direction.x) == -1 && (direction.y > -0.5 && direction.y < 0.5))
                {
                    this.transform.Rotate(0,-90,0);
                }
                
                else
                {
                    this.transform.Rotate(0,0,0);
                }
                
            }
            moveDirection.y = currentDirection;
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
                //playerInteract.interact(true);
            }
        }

        protected void OnInteractHold()
        {
            if (GameManager.Instance.checkIfPlayerIsActive(currentPlayer))
            {
                playerInteract.interact(released);
                released = !released;
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

        protected void OnMenuExit()
        {
            if (GameManager.Instance.currentTutorial != null)
            {
                GameManager.Instance.exitTutorial();
            }
            else if (inputType == InputType.Keyboard && !GameManager.Instance.paused)
            {
                InGameMenu.SetActive(!InGameMenu.activeSelf);

                if (Time.timeScale == 0)
                {
                    Time.timeScale = 1;
                }
                else
                {
                    Time.timeScale = 0;
                }
            }
        }

        private void OnMenuExitController()
        {
            if (!GameManager.Instance.paused)
            {
                InGameMenu.SetActive(!InGameMenu.activeSelf);

                if (Time.timeScale == 0)
                {
                    Time.timeScale = 1;
                }
                else
                {
                    Time.timeScale = 0;
                }
            }
        }

        private void OnSkipCutscene()
        {
            foreach(GameObject fullCutscene in cutsceneTriggers)
            {
                ISkipable cutscene = fullCutscene.GetComponent<ISkipable>();
                cutscene.Skip();
            }
        }

        public void setInputType(InputType inputType)
        {
            this.inputType = inputType;
            if (inputType == InputType.Controller)
            {
                rotationSpeed /= 2;
            }
        }

        public void togglePush()
        {
            canPushPull = !canPushPull;
            if (!canPushPull)
            {
                gameObject.GetComponent<Animator>().SetBool("pushing", false);
            }
        }
    }
}
