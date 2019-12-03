using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts
{
    public class ControllerManager : MonoBehaviour
    {
        [Header("If both are controller then make sure there are 2 controllers connected!")]
        public InputType inputDeviceP1;
        public InputType inputDeviceP2;

        private GameObject playerOne;
        private GameObject playerTwo;

        // Start is called before the first frame update
        void Start()
        {
            if (GameManager.Instance.GameType == GameType.MultiPlayerSplitScreen)
            {
                setPlayers();
            }

            if (GameManager.Instance.GameType == GameType.SinglePlayer)
            {
                GameManager.Instance.assignController(GameManager.Instance.PlayerOne, InputType.Keyboard, Keyboard.current, Mouse.current);
                GameManager.Instance.assignController(GameManager.Instance.PlayerTwo, InputType.Keyboard, Keyboard.current, Mouse.current);
            }
            else
            {
                if (inputDeviceP1 == InputType.Controller && inputDeviceP2 == InputType.Controller && Gamepad.all.Count > 1)
                {
                    var gamepads = Gamepad.all;

                    GameManager.Instance.assignController(GameManager.Instance.PlayerOne, InputType.Controller, gamepads[0]);
                    GameManager.Instance.assignController(GameManager.Instance.PlayerTwo, InputType.Controller, gamepads[1]);
                }
                else if (inputDeviceP1 == InputType.Controller && inputDeviceP2 == InputType.Keyboard)
                {
                    GameManager.Instance.assignController(GameManager.Instance.PlayerOne, InputType.Controller, Gamepad.current);
                    GameManager.Instance.assignController(GameManager.Instance.PlayerTwo, InputType.Keyboard, Keyboard.current, Mouse.current);
                }
                else
                {
                    GameManager.Instance.assignController(GameManager.Instance.PlayerOne, InputType.Keyboard, Keyboard.current, Mouse.current);
                    GameManager.Instance.assignController(GameManager.Instance.PlayerTwo, InputType.Controller, Gamepad.current);
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            CinemachineCore.GetInputAxis = getAxisCustom;
        }

        public void setPlayers()
        {
            if (GameManager.Instance.GameType == GameType.SinglePlayer)
            {
                if (GameManager.Instance.PlayerOne == ActivePlayer.Human)
                {
                    playerOne = GameManager.Instance.Human;
                }
                else
                {
                    playerOne = GameManager.Instance.Animal;
                }
            }
            else if (GameManager.Instance.PlayerOne == ActivePlayer.Human)
            {
                playerOne = GameManager.Instance.Human;
                playerTwo = GameManager.Instance.Animal;
            }
            else
            {
                playerOne = GameManager.Instance.Human;
                playerTwo = GameManager.Instance.Animal;
            }
        }

        public float getAxisCustom(string axisName)
        {
            if (GameManager.Instance.GameType == GameType.SinglePlayer)
            {
                setPlayers();
                if (axisName == "Camera X")
                {
                    return playerOne.GetComponent<Player>().cameraDirection.x;
                }
                else
                {
                    return playerOne.GetComponent<Player>().cameraDirection.y;
                }
            }
            else
            {
                if (axisName == "Camera X")
                {
                    return playerOne.GetComponent<Player>().cameraDirection.x;
                }
                else if (axisName == "Camera Y")
                {
                    return playerOne.GetComponent<Player>().cameraDirection.y;
                }
                if (axisName == "Camera X P2")
                {
                    return playerTwo.GetComponent<Player>().cameraDirection.x;
                }
                else
                {
                    return playerTwo.GetComponent<Player>().cameraDirection.y;
                }
            }
        }
    }
}