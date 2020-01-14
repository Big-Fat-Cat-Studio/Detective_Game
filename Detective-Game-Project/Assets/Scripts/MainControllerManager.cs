using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class MainControllerManager : MonoBehaviour
    {
        public InputType inputDeviceP1 = InputType.Controller;
        public InputType inputDeviceP2 = InputType.Controller;

        //Singleton, so we can access human/animal everywhere
        public static MainControllerManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        public void setInputDeviceP1(InputType input)
        {
            inputDeviceP1 = input;
        }

        public void setInputDeviceP2(InputType input)
        {
            inputDeviceP2 = input;
        }
    }
}