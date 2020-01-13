using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    public class MenuControls : MonoBehaviour
    {
        public GameObject Player1, Player2;
        int P1Value, P2Value;

        void OnEnable()
        {
            Player1.GetComponent<Dropdown>().Select();
            P1Value = Player1.GetComponent<Dropdown>().value;
            P2Value = Player2.GetComponent<Dropdown>().value;
        }

        public void NoTwoKeyboardsP1()
        {
            if (P1Value == 0 && P2Value == 1)
            {
                Player2.GetComponent<Dropdown>().value = 0;
            }
        }

        public void NoTwoKeyboardsP2()
        {
            if (P2Value == 0 && P1Value == 1)
            {
                Player1.GetComponent<Dropdown>().value = 0;
            }
        }

        public void setInputDeviceP1()
        {
            if(Player1.GetComponent<Dropdown>().value == 0)
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
            if (Player2.GetComponent<Dropdown>().value == 0)
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
