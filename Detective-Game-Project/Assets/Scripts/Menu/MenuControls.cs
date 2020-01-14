using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuControls : MonoBehaviour
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
            Player2.SetActive(false);
            Player2.SetActive(true);
            Player2.GetComponent<TMP_Dropdown>().value = 0;

        }
    }

    public void NoTwoKeyboardsP2()
    {
        if (P2Value == 0)
        {
            Player1.SetActive(false);
            Player1.SetActive(true);
            Player1.GetComponent<TMP_Dropdown>().value = 0;

        }
    }
}
