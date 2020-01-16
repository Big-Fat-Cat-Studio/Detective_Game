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
        public InputType inputTypeP1;
        public InputType inputTypeP2;

        private GameObject playerOne;
        private GameObject playerTwo;

        private int amountOfControllers;
        private int amountOfControllersNeeded;
        private List<InputDevice> listOfDevices;

        private InputDevice inputDeviceP1 = null;
        private InputDevice inputDeviceP2 = null;

        // Start is called before the first frame update
        void Start()
        {
            listOfDevices = new List<InputDevice>();

            if (MainControllerManager.Instance != null)
            {
                inputTypeP1 = MainControllerManager.Instance.inputDeviceP1;
                inputTypeP2 = MainControllerManager.Instance.inputDeviceP2;
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
                //var gamepads = Gamepad.all;
                List<Gamepad> gamepads = Gamepad.all.Where(gamepad => !gamepad.name.StartsWith("DualShock")).ToList();
                amountOfControllers = gamepads.Count;

                if (inputTypeP1 == InputType.Controller && inputTypeP2 == InputType.Controller)
                {
                    amountOfControllersNeeded = 2;

                    if (amountOfControllers > 0)
                    {
                        GameManager.Instance.assignController(GameManager.Instance.PlayerOne, InputType.Controller, gamepads[0]);
                        inputDeviceP1 = gamepads[0];

                        if (amountOfControllers > 1)
                        {
                            GameManager.Instance.assignController(GameManager.Instance.PlayerTwo, InputType.Controller, gamepads[1]);
                            inputDeviceP2 = gamepads[1];
                        }
                    }
                }
                else if (inputTypeP1 == InputType.Controller && inputTypeP2 == InputType.Keyboard)
                {
                    amountOfControllersNeeded = 1;

                    if (amountOfControllers > 0)
                    {
                        GameManager.Instance.assignController(GameManager.Instance.PlayerOne, InputType.Controller, gamepads[0]);
                        inputDeviceP1 = gamepads[0];
                    }
                    GameManager.Instance.assignController(GameManager.Instance.PlayerTwo, InputType.Keyboard, Keyboard.current, Mouse.current);
                    inputDeviceP2 = Keyboard.current;
                }
                else if (inputTypeP1 == InputType.Keyboard && inputTypeP2 == InputType.Controller)
                {
                    amountOfControllersNeeded = 1;

                    GameManager.Instance.assignController(GameManager.Instance.PlayerOne, InputType.Keyboard, Keyboard.current, Mouse.current);
                    inputDeviceP1 = Keyboard.current;

                    if (amountOfControllers > 0)
                    {
                        GameManager.Instance.assignController(GameManager.Instance.PlayerTwo, InputType.Controller, gamepads[0]);
                        inputDeviceP2 = gamepads[0];
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
            yield return new WaitForSeconds(2);
            InputSystem.onDeviceChange += (device, change) =>
            {
                switch (change)
                {
                    case InputDeviceChange.Added:
                        if (!device.name.StartsWith("DualShock"))
                        {
                            Debug.Log("New device added: " + device);
                            if (amountOfControllers < amountOfControllersNeeded && !listOfDevices.Contains(device))
                            {
                                if (amountOfControllersNeeded == 2)
                                {
                                    if (amountOfControllers == 0)
                                    {
                                        GameManager.Instance.assignController(GameManager.Instance.PlayerOne, InputType.Controller, device);
                                        inputDeviceP1 = device;
                                    }
                                    else
                                    {
                                        GameManager.Instance.assignController(GameManager.Instance.PlayerTwo, InputType.Controller, device);
                                        inputDeviceP2 = device;
                                    }
                                }
                                else
                                {
                                    if (inputTypeP1 == InputType.Controller)
                                    {
                                        GameManager.Instance.assignController(GameManager.Instance.PlayerOne, InputType.Controller, device);
                                        inputDeviceP1 = device;
                                    }
                                    else
                                    {
                                        GameManager.Instance.assignController(GameManager.Instance.PlayerTwo, InputType.Controller, device);
                                        inputDeviceP2 = device;
                                    }
                                }

                                listOfDevices.Add(device);
                                amountOfControllers++;
                            }
                        }
                        goto default;
                    //break;
                    case InputDeviceChange.Disconnected:
                        Debug.Log("Device removed: " + device);
                        if (inputDeviceP1 == device)
                        {
                            GameManager.Instance.turnOffController(GameManager.Instance.PlayerOne);

                            if (inputTypeP2 == InputType.Controller)
                            {
                                GameManager.Instance.keepControllerOn(GameManager.Instance.PlayerTwo, inputDeviceP2);
                            }
                        }
                        else if (inputDeviceP2 == device)
                        {
                            GameManager.Instance.turnOffController(GameManager.Instance.PlayerTwo);
                            if (inputTypeP1 == InputType.Controller)
                            {
                                GameManager.Instance.keepControllerOn(GameManager.Instance.PlayerOne, inputDeviceP1);
                            }
                        }
                        goto default;
                    //break;
                    case InputDeviceChange.Reconnected:
                        if (inputDeviceP1 == device)
                        {
                            GameManager.Instance.turnOnController(GameManager.Instance.PlayerOne, inputDeviceP1);
                        }
                        else if (inputDeviceP2 == device)
                        {
                            GameManager.Instance.turnOnController(GameManager.Instance.PlayerTwo, inputDeviceP2);
                        }
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
