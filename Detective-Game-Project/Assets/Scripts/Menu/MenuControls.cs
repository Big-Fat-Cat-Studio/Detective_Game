using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Scripts
{
    public class MenuControls : MonoBehaviour
    {
        public GameObject Player1, Player2;
        public TMP_Dropdown DropdownP1, DropdownP2;
        int P1Value, P2Value;

        // ADD FUNCTION FOR INVERTED CAMERA

        void Start()
        {
            int P1Level = PlayerPrefs.GetInt("ControlP1", 0);
            print(P1Level);
            DropdownP1.value = P1Level;
            DropdownP1.RefreshShownValue();

            int P2Level = PlayerPrefs.GetInt("ControlP2", 0);
            print(P2Level);
            DropdownP2.value = P2Level;
            DropdownP2.RefreshShownValue();
        }

        void OnEnable()
        {
            Player1.SetActive(false);
            Player1.SetActive(true);
            DropdownP1.Select();

            P1Value = DropdownP1.value;
            P2Value = DropdownP2.value;
        }

        public void NoTwoKeyboardsP1()
        {
            if (P1Value == 0)
            {
                DropdownP2.value = 0;
                Player2.SetActive(false);
                Player2.SetActive(true);
                P2Value = DropdownP2.value;

                DropdownP1.value = 1;
                Player1.SetActive(false);
                Player1.SetActive(true);
                P1Value = DropdownP1.value;
            }
        }

        public void NoTwoKeyboardsP2()
        {
            if (P2Value == 0)
            {
                DropdownP1.value = 0;
                Player1.SetActive(false);
                Player1.SetActive(true);
                P1Value = DropdownP1.value;

                DropdownP2.value = 1;
                Player2.SetActive(false);
                Player2.SetActive(true);
                P2Value = DropdownP2.value;
            }
        }

        public void setInputDeviceP1()
        {
            if(DropdownP1.value == 0)
            {
                MainControllerManager.Instance.setInputDeviceP1(InputType.Controller);
            }
            else
            {
                MainControllerManager.Instance.setInputDeviceP1(InputType.Keyboard);
            }
        }

        public void setInputDeviceP2()
        {
            if (DropdownP2.value == 0)
            {
                MainControllerManager.Instance.setInputDeviceP2(InputType.Controller);
            }
            else
            {
                MainControllerManager.Instance.setInputDeviceP2(InputType.Keyboard);
            }
        }
    }
}
