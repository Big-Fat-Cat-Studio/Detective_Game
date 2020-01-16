using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class MainControllerManager : MonoBehaviour
    {
        public InputType inputDeviceP1;
        public InputType inputDeviceP2;

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

        private void Start()
        {
            inputDeviceP1 = (InputType)PlayerPrefs.GetInt("ControlP1", 0);
            inputDeviceP2 = (InputType)PlayerPrefs.GetInt("ControlP2", 0);
        }

        public void setInputDeviceP1(InputType input)
        {
            inputDeviceP1 = input;
            PlayerPrefs.SetInt("ControlP1", (int)input);
        }

        public void setInputDeviceP2(InputType input)
        {
            inputDeviceP2 = input;
            PlayerPrefs.SetInt("ControlP2", (int)input);
        }
    }
}