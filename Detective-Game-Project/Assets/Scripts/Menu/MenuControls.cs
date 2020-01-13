﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        if (P1Value == 0)
        {
            Player2.GetComponent<Dropdown>().value = 0;
            Player2.SetActive(false);
            Player2.SetActive(true);
        }
    }

    public void NoTwoKeyboardsP2()
    {
        if (P2Value == 0)
        {
            Player1.GetComponent<Dropdown>().value = 0;
            Player1.SetActive(false);
            Player1.SetActive(true);
        }
    }
}
