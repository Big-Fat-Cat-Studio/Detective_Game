using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Scripts
{
    public GameObject Player1, Player2;
    int P1Value, P2Value;

    // ADD FUNCTION FOR INVERTED CAMERA

    void OnEnable()
    {
        Player1.SetActive(false);
        Player1.SetActive(true);
        Player1.GetComponent<TMP_Dropdown>().Select();
        P1Value = Player1.GetComponent<TMP_Dropdown>().value;
        P2Value = Player2.GetComponent<TMP_Dropdown>().value;
    }

        public void NoTwoKeyboardsP1()
        {
            if (P1Value == 0)
            {
                Player2.GetComponent<TMP_Dropdown>().value = 0;
                Player2.SetActive(false);
                Player2.SetActive(true);
            }
        }

        public void NoTwoKeyboardsP2()
        {
            if (P2Value == 0)
            {
                Player1.GetComponent<TMP_Dropdown>().value = 0;
                Player1.SetActive(false);
                Player1.SetActive(true);
            }
        }

        public void setInputDeviceP1()
        {
            if(Player1.GetComponent<TMP_Dropdown>().value == 0)
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
            if (Player2.GetComponent<TMP_Dropdown>().value == 0)
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
