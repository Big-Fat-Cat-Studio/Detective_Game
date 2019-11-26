using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using System.Collections;

namespace Scripts
{
    public class GameManager : MonoBehaviour
    {

        //Singleton, so we can access human/animal everywhere
        public static GameManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        public GameType GameType;
        public GameObject Human;
        public GameObject Animal;

        [Header("These won't be used in singleplayer.")]
        public ActivePlayer PlayerOne;
        public ActivePlayer PlayerTwo;

        [HideInInspector]
        public ActivePlayer? InteractTextActivePlayer;

        [Header("Text game objects")]
        public GameObject AfterInteractText;
        public GameObject InteractText;

        [Header("PLAYER ONE Text game objects")]
        //Player one gameobjects instead of putting player two gameobjects because 
        //the text game objects are on the right spot for player two
        public GameObject AfterInteractTextPlayerOne;
        public GameObject InteractTextPlayerOne;

        private IEnumerator currentCourotine;
        private IEnumerator currentCourotinePlayerOne;

        [Header("Camera objects")]
        public GameObject PlayerCamera;
        public GameObject PlayerCameraP2;

        [Header("Freelook objects")]
        public GameObject CameraFollow;
        public GameObject CameraFollowP2;

        private float _PrevPlayerORotation; // Object X-Axis Rotation
        private float _PrevPlayerCRotation; // Camera X-Axis Rotation
        private void Start()
        {
            if (GameType == GameType.SinglePlayer)
            {
                PlayerOne = ActivePlayer.Human;

                PlayerCamera.GetComponent<Camera>().rect = new Rect(0,0,1,1);
                PlayerCameraP2.SetActive(false);
            }
            else if (PlayerTwo == ActivePlayer.Human) {
                CameraFollowP2.GetComponent<CinemachineFreeLook>().m_XAxis.m_InputAxisName = "Camera X";
                CameraFollowP2.GetComponent<CinemachineFreeLook>().m_YAxis.m_InputAxisName = "Camera Y";
                PlayerCameraP2.GetComponent<Camera>().rect = new Rect(0, 0.5f, 1, 1);

                CameraFollow.GetComponent<CinemachineFreeLook>().m_XAxis.m_InputAxisName = "Camera X P2";
                CameraFollow.GetComponent<CinemachineFreeLook>().m_YAxis.m_InputAxisName = "Camera Y P2";
                PlayerCamera.GetComponent<Camera>().rect = new Rect(0, -0.5f, 1, 1);
            }

            AfterInteractText.SetActive(false);
            InteractText.SetActive(false);
            AfterInteractTextPlayerOne.SetActive(false);
            InteractTextPlayerOne.SetActive(false);

            currentCourotine = null;
            currentCourotinePlayerOne = null;
        }

        // Update is called once per frame
        private void Update()
        {
            if (GameType == GameType.SinglePlayer && Input.GetButtonDown("Swap"))
            {
                CinemachineFreeLook cameraContext = CameraFollow.GetComponent<CinemachineFreeLook>();

                if (PlayerOne == ActivePlayer.Human)
                {
                    cameraContext.Follow = Animal.transform;
                    cameraContext.LookAt = Animal.transform;
                    PlayerOne = ActivePlayer.Animal;
                }
                else if (PlayerOne == ActivePlayer.Animal)
                {
                    cameraContext.Follow = Human.transform;
                    cameraContext.LookAt = Human.transform;
                    PlayerOne = ActivePlayer.Human;
                }

                var tempX = cameraContext.m_XAxis.Value;
                cameraContext.m_XAxis.Value = _PrevPlayerCRotation;
                _PrevPlayerCRotation = tempX;
            }
        }

        public bool checkIfPlayerIsActive(ActivePlayer player)
        {
            if (GameType == GameType.SinglePlayer)
            {
                if (PlayerOne == player)
                {
                    return true;
                }
                return false;
            }
            return true;
        }

        public bool getButtonPressForPlayer(ActivePlayer player, string buttonName, ButtonPress buttonPress)
        { 
            if (GameType == GameType.MultiPlayerSplitScreen && player == PlayerTwo)
            {
                buttonName += " P2";
            }
            
            if(buttonPress == ButtonPress.Down)
            {
                return Input.GetButtonDown(buttonName);
            }
            else if (buttonPress == ButtonPress.Up)
            {
                return Input.GetButtonUp(buttonName);
            }
            else 
            {
                return Input.GetButton(buttonName);
            }
        }
        
        public float getAxisForPlayer(ActivePlayer player, string axisName, AxisType axisType)
        {
            if (GameType == GameType.MultiPlayerSplitScreen && player == PlayerTwo)
            {
                axisName += " P2";
            }

            if (axisType == AxisType.Axis)
            {
                return Input.GetAxis(axisName);
            }
            else
            {
                return Input.GetAxisRaw(axisName);
            }
        }

        public void removeInteractText(ActivePlayer player)
        {
            if (GameType == GameType.MultiPlayerSplitScreen)
            {
                if (player == PlayerOne)
                {
                    InteractTextPlayerOne.SetActive(false);
                }
                else
                {
                    InteractText.SetActive(false);
                }
            }
            else
            {
                if (InteractTextActivePlayer == player)
                {
                    InteractText.SetActive(false);
                    InteractTextActivePlayer = null;
                }
            }
        }

        public void showInteractText(string message, ActivePlayer player)
        {
            if (GameType == GameType.MultiPlayerSplitScreen && player == PlayerOne)
            {
                InteractTextPlayerOne.GetComponent<Text>().text = Constant.INTERACT_TEXT + message;
                InteractTextPlayerOne.SetActive(true);
            }
            else
            {
                InteractText.GetComponent<Text>().text = Constant.INTERACT_TEXT + message;
                InteractText.SetActive(true);

                if (GameType == GameType.SinglePlayer)
                {
                    InteractTextActivePlayer = player;
                }
            }
        }

        public void showAfterInteractText(ActivePlayer player, string message)
        {
            if (GameType == GameType.MultiPlayerSplitScreen && player == PlayerOne)
            {
                AfterInteractTextPlayerOne.GetComponent<Text>().text = message;
                AfterInteractTextPlayerOne.SetActive(true);

                if (currentCourotinePlayerOne != null)
                {
                    StopCoroutine(currentCourotinePlayerOne);
                }

                currentCourotinePlayerOne = afterInteractTextDisappear(PlayerOne);
                StartCoroutine(currentCourotinePlayerOne);
            }
            else
            {
                AfterInteractText.GetComponent<Text>().text = message;
                AfterInteractText.SetActive(true);

                if (currentCourotine != null)
                {
                    StopCoroutine(currentCourotine);
                }

                if (GameType == GameType.SinglePlayer)
                {
                    currentCourotine = afterInteractTextDisappear(PlayerOne);
                }
                else
                {
                    currentCourotine = afterInteractTextDisappear(PlayerTwo);
                }

                StartCoroutine(currentCourotine);
            }
        }

        IEnumerator afterInteractTextDisappear(ActivePlayer player)
        {
            yield return new WaitForSecondsRealtime(6);
            if (player == PlayerOne && GameType == GameType.MultiPlayerSplitScreen)
            {
                AfterInteractTextPlayerOne.SetActive(false);
                currentCourotinePlayerOne = null;
            }
            else
            {
                AfterInteractText.SetActive(false);
                currentCourotine = null;
            }
            
        }
    }
}