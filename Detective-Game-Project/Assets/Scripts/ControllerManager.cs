using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        private int amountOfControllers;
        private int amountOfControllersNeeded;
        private List<InputDevice> listOfDevices;

        // Start is called before the first frame update
        void Start()
        {
            listOfDevices = new List<InputDevice>();

            if (MainControllerManager.Instance != null)
            {
                inputDeviceP1 = MainControllerManager.Instance.inputDeviceP1;
                inputDeviceP2 = MainControllerManager.Instance.inputDeviceP2;
            }

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
                var gamepads = Gamepad.all;
                amountOfControllers = Gamepad.all.Count;

                if (inputDeviceP1 == InputType.Controller && inputDeviceP2 == InputType.Controller)
                {
                    amountOfControllersNeeded = 2;

                    if (amountOfControllers > 0)
                    {
                        GameManager.Instance.assignController(GameManager.Instance.PlayerOne, InputType.Controller, gamepads[0]);

                        if (amountOfControllers > 1)
                        {
                            GameManager.Instance.assignController(GameManager.Instance.PlayerTwo, InputType.Controller, gamepads[1]);
                        }
                    }
                }
                else if (inputDeviceP1 == InputType.Controller && inputDeviceP2 == InputType.Keyboard)
                {
                    if (amountOfControllers > 0)
                    {
                        GameManager.Instance.assignController(GameManager.Instance.PlayerOne, InputType.Controller, gamepads[0]);
                    }
                    else
                    {
                        amountOfControllersNeeded = 1;
                    }

                    GameManager.Instance.assignController(GameManager.Instance.PlayerTwo, InputType.Keyboard, Keyboard.current, Mouse.current);
                }
                else if (inputDeviceP1 == InputType.Keyboard && inputDeviceP2 == InputType.Controller)
                {
                    GameManager.Instance.assignController(GameManager.Instance.PlayerOne, InputType.Keyboard, Keyboard.current, Mouse.current);

                    if (amountOfControllers > 0)
                    {
                        GameManager.Instance.assignController(GameManager.Instance.PlayerTwo, InputType.Controller, gamepads[0]);
                    }
                    else
                    {
                        amountOfControllersNeeded = 1;
                    }
                }
                else
                {
                    GameManager.Instance.assignController(GameManager.Instance.PlayerOne, InputType.Keyboard, Keyboard.current, Mouse.current);
                    GameManager.Instance.assignController(GameManager.Instance.PlayerTwo, InputType.Keyboard, Keyboard.current, Mouse.current);                    
                }
            }
            StartCoroutine(checkForControllers());
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

        private IEnumerator checkForControllers()
        {
            yield return new WaitForSeconds(3);
            InputSystem.onDeviceChange += (device, change) =>
            {
                switch (change)
                {
                    case InputDeviceChange.Added:
                        Debug.Log("New device added: " + device);
                        if (amountOfControllers < amountOfControllersNeeded && !listOfDevices.Contains(device))
                        {
                            if (amountOfControllersNeeded == 2)
                            {
                                if (amountOfControllers == 0)
                                {
                                    GameManager.Instance.assignController(GameManager.Instance.PlayerOne, InputType.Controller, device);
                                }
                                else
                                {
                                    GameManager.Instance.assignController(GameManager.Instance.PlayerTwo, InputType.Controller, device);
                                }
                            }
                            else
                            {
                                if (inputDeviceP1 == InputType.Controller)
                                {
                                    GameManager.Instance.assignController(GameManager.Instance.PlayerOne, InputType.Controller, device);
                                }
                                else
                                {
                                    GameManager.Instance.assignController(GameManager.Instance.PlayerTwo, InputType.Controller, device);
                                }
                            }

                            listOfDevices.Add(device);
                            amountOfControllers++;
                        }
                        goto default;
                    //break;
                    case InputDeviceChange.Removed:
                        Debug.Log("Device removed: " + device);
                        goto default;
                    //break;
                    default:
                        print(change.ToString());
                        break;
                }
            };

            yield return StartCoroutine(checkForControllers());
        }
    }
}
