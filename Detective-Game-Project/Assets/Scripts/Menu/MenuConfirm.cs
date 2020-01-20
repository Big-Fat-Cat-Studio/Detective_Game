using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuConfirm : MonoBehaviour
{
    public GameObject Yes, No;

    public void SelectYes()
    {
        Yes.GetComponent<Button>().Select();
    }

    public void SelectNo()
    {
        No.GetComponent<Button>().Select();
    }
}
