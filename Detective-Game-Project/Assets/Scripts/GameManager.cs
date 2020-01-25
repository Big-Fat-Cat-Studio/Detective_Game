﻿using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using System.Collections.Generic;
using System;
using TMPro;

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
            //Instance = this;
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
        public GameObject AfterInteractTextP2;
        public GameObject InteractTextP2;

        public GameObject DisconnectedP1;
        public GameObject DisconnectedP2;

        [Header("General counter for key object")]
        public GameObject KeyCounter; // Text Object
        public Byte KeyCounterRequired; // Actual number of keyparts required
        public Byte KeyCounterActual; // Actual number of keyparts collected

        [Header("PLAYER ONE Text game objects")]
        //Player one gameobjects instead of putting player two gameobjects because
        //the text game objects are on the right spot for player two
        public GameObject AfterInteractTextP1;
        public GameObject InteractTextP1;

        private IEnumerator currentCourotine;
        private IEnumerator currentCourotinePlayerOne;

        [Header("Camera objects")]
        public GameObject PlayerCamera;
        public GameObject PlayerCameraP2;
        public GameObject CutsceneCamera;

        [Header("Freelook objects")]
        public GameObject CameraFollow;
        public GameObject CameraFollowP2;

        private float _PrevPlayerORotation; // Object X-Axis Rotation
        private float _PrevPlayerCRotation; // Camera X-Axis Rotation
        private List<MeshHighlighter> clues = new List<MeshHighlighter>();

        private InputType playerInput;
        private InputType playerOneInput;
        [HideInInspector]
        public bool paused;

        [HideInInspector]
        public Tutorial currentTutorial;
        //public SaveData saveData;

        private void Start()
        {
            // saveData = SaveSystem.LoadProgress();
            CameraFollow.GetComponent<CinemachineFreeLook>().Follow = Human.transform;
            CameraFollow.GetComponent<CinemachineFreeLook>().LookAt = Human.transform;
            CameraFollowP2.GetComponent<CinemachineFreeLook>().Follow = Animal.transform;
            CameraFollowP2.GetComponent<CinemachineFreeLook>().LookAt = Animal.transform;

            if (GameType == GameType.SinglePlayer)
            {
                PlayerOne = ActivePlayer.Human;

                PlayerCamera.GetComponent<Camera>().rect = new Rect(0,0,1,1);
                PlayerCameraP2.SetActive(false);
                CameraFollow.GetComponent<CinemachineFreeLook>().Follow = Human.transform;
                CameraFollow.GetComponent<CinemachineFreeLook>().LookAt = Human.transform;
            }
            else if (GameType == GameType.MultiPlayerSplitScreen) {
                //PlayerOne = CharacterManager.Instance.PlayerOne;
                //PlayerTwo = CharacterManager.Instance.PlayerTwo;
                if (PlayerOne == ActivePlayer.Human)
                {
                    CameraFollow.GetComponent<CinemachineFreeLook>().m_XAxis.m_InputAxisName = "Camera X";
                    CameraFollow.GetComponent<CinemachineFreeLook>().m_YAxis.m_InputAxisName = "Camera Y";
                    CameraFollowP2.GetComponent<CinemachineFreeLook>().m_XAxis.m_InputAxisName = "Camera X P2";
                    CameraFollowP2.GetComponent<CinemachineFreeLook>().m_YAxis.m_InputAxisName = "Camera Y P2";

                    CameraFollow.GetComponent<CinemachineFreeLook>().Follow = Human.transform;
                    CameraFollow.GetComponent<CinemachineFreeLook>().LookAt = Human.transform;
                    CameraFollowP2.GetComponent<CinemachineFreeLook>().Follow = Animal.transform;
                    CameraFollowP2.GetComponent<CinemachineFreeLook>().LookAt = Animal.transform;
                }
                else if (PlayerTwo == ActivePlayer.Human)
                {
                    CameraFollowP2.GetComponent<CinemachineFreeLook>().m_XAxis.m_InputAxisName = "Camera X";
                    CameraFollowP2.GetComponent<CinemachineFreeLook>().m_YAxis.m_InputAxisName = "Camera Y";
                    PlayerCameraP2.GetComponent<Camera>().rect = new Rect(0, 0.5f, 1, 1);

                    CameraFollow.GetComponent<CinemachineFreeLook>().m_XAxis.m_InputAxisName = "Camera X P2";
                    CameraFollow.GetComponent<CinemachineFreeLook>().m_YAxis.m_InputAxisName = "Camera Y P2";
                    PlayerCamera.GetComponent<Camera>().rect = new Rect(0, -0.5f, 1, 1);

                    CameraFollowP2.GetComponent<CinemachineFreeLook>().Follow = Human.transform;
                    CameraFollowP2.GetComponent<CinemachineFreeLook>().LookAt = Human.transform;
                    CameraFollow.GetComponent<CinemachineFreeLook>().Follow = Animal.transform;
                    CameraFollow.GetComponent<CinemachineFreeLook>().LookAt = Animal.transform;
                }
            }

            AfterInteractTextP2.SetActive(false);
            InteractTextP2.SetActive(false);
            AfterInteractTextP1.SetActive(false);
            InteractTextP1.SetActive(false);
            KeyCounter.SetActive(false);

            currentCourotine = null;
            currentCourotinePlayerOne = null;

            // Init the key counter if needed
            InitKeyCounter();
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

            // If counter is anything other than 0 it's initialized.
            if (KeyCounterActual > 0)
                UpdateKeyCounter();
        }

        public void openMenu()
        {
            if (currentTutorial != null)
            {
                exitTutorial();
            }
            else
            {
                Human.GetComponent<Player>().openMenu();
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

        public void assignController(ActivePlayer player, InputType inputType, params InputDevice[] inputs)
        {
            if (player == ActivePlayer.Animal)
            {
                Animal.GetComponent<Player>().setInputType(inputType);
                Animal.GetComponent<PlayerInput>().enabled = true;
                Animal.GetComponent<PlayerInput>().SwitchCurrentControlScheme(inputType.ToString(), inputs);
            }
            else
            {
                Human.GetComponent<Player>().setInputType(inputType);
                Human.GetComponent<PlayerInput>().enabled = true;
                Human.GetComponent<PlayerInput>().SwitchCurrentControlScheme(inputType.ToString(), inputs);
            }

            if (player == PlayerOne)
            {
                playerOneInput = inputType;
            }
            else
            {
                playerInput = inputType;
            }
        }

        public void turnOffController(ActivePlayer player)
        {
            if (player == ActivePlayer.Animal)
            {
                Animal.GetComponent<PlayerInput>().enabled = false;
            }
            else
            {
                Human.GetComponent<PlayerInput>().enabled = false;
            }
        }

        public void turnOnController(ActivePlayer player, params InputDevice[] inputs)
        {
            if (player == ActivePlayer.Animal)
            {
                Animal.GetComponent<PlayerInput>().enabled = true;
                Animal.GetComponent<PlayerInput>().SwitchCurrentControlScheme(Animal.GetComponent<Player>().inputType.ToString(), inputs);
            }
            else
            {
                Human.GetComponent<PlayerInput>().enabled = true;
                Human.GetComponent<PlayerInput>().SwitchCurrentControlScheme(Human.GetComponent<Player>().inputType.ToString(), inputs);
            }
        }

        public void keepControllerOn(ActivePlayer player, params InputDevice[] inputs)
        {
            if (player == ActivePlayer.Animal && Animal.GetComponent<PlayerInput>().enabled)
            {
                Animal.GetComponent<PlayerInput>().SwitchCurrentControlScheme(Animal.GetComponent<Player>().inputType.ToString(), inputs);
            }
            else if (player == ActivePlayer.Human && Human.GetComponent<PlayerInput>().enabled)
            {
                Human.GetComponent<PlayerInput>().SwitchCurrentControlScheme(Human.GetComponent<Player>().inputType.ToString(), inputs);
            }
        }

        public void removeInteractText(ActivePlayer player)
        {
            if (GameType == GameType.MultiPlayerSplitScreen)
            {
                if (player == PlayerOne)
                {
                    InteractTextP1.SetActive(false);
                }
                else
                {
                    InteractTextP2.SetActive(false);
                }
            }
            else
            {
                if (InteractTextActivePlayer == player)
                {
                    InteractTextP2.SetActive(false);
                    InteractTextActivePlayer = null;
                }
            }
        }

        public void showInteractText(string message, ActivePlayer player, bool isHoldPrompt)
        {
            print(message);
            if (GameType == GameType.MultiPlayerSplitScreen && player == PlayerOne)
            {
                if (playerOneInput == InputType.Controller)
                {
                    InteractTextP1.GetComponent<TextMeshProUGUI>().text = message;
                    InteractTextP1.SetActive(true);
                }
                else
                {
                    InteractTextP1.GetComponent<TextMeshProUGUI>().text = message;
                    InteractTextP1.SetActive(true);
                }
            }
            else
            {
                if (playerInput == InputType.Controller)
                {
                    InteractTextP2.GetComponent<TextMeshProUGUI>().text = message;
                    InteractTextP2.SetActive(true);
                }
                else
                {
                    InteractTextP2.GetComponent<TextMeshProUGUI>().text = message;
                    InteractTextP2.SetActive(true);
                }

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
                AfterInteractTextP1.GetComponent<TextMeshProUGUI>().text = message;
                AfterInteractTextP1.SetActive(true);

                if (currentCourotinePlayerOne != null)
                {
                    StopCoroutine(currentCourotinePlayerOne);
                }

                currentCourotinePlayerOne = afterInteractTextDisappear(PlayerOne);
                StartCoroutine(currentCourotinePlayerOne);
            }
            else
            {
                AfterInteractTextP2.GetComponent<TextMeshProUGUI>().text = message;
                AfterInteractTextP2.SetActive(true);

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
                AfterInteractTextP1.SetActive(false);
                currentCourotinePlayerOne = null;
            }
            else
            {
                AfterInteractTextP2.SetActive(false);
                currentCourotine = null;
            }

        }

        public void toggleOnDisconnectIconP1()
        {
            DisconnectedP1.SetActive(true);
        }

        public void toggleOffDisconnectIconP1()
        {
            DisconnectedP1.SetActive(false);
        }

        public void toggleOnDisconnectIconP2()
        {
            DisconnectedP2.SetActive(true);
        }

        public void toggleOffDisconnectIconP2()
        {
            DisconnectedP2.SetActive(false);
        }

        public void InitKeyCounter()
        {
            Key keyComponent = FindObjectOfType<Key>();
            if (keyComponent != null)
            {
                KeyCounterRequired = (byte)keyComponent.amountNeeded;
                KeyCounter.SetActive(true);
            }
        }

        public void UpdateKeyCounter()
        {
            KeyCounter.GetComponent<TextMeshProUGUI>().text = $"{KeyCounterActual}/{KeyCounterRequired}";
        }

        public string getPlayerName(ActivePlayer player)
        {
            if(player == ActivePlayer.Human)
            {
                return "Kika";
            }
            else
            {
                return "Daigo";
            }
        }

        public void addCluesToList(MeshHighlighter clue)
        {
            clues.Add(clue);
        }

        public void toggleVision()
        {
            clues.ForEach(clue => clue.toggleClues());
        }

        public void exitTutorial()
        {
            if (currentTutorial != null)
            {
                currentTutorial.Resume();
                currentTutorial = null;
            }
        }

        public void pauseGame()
        {
            paused = !paused;
        }
    }
}
