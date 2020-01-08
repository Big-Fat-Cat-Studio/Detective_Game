using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventSystemSwitcher : MonoBehaviour
{
    public GameObject SwitchTo;
    public UnityEngine.EventSystems.EventSystem CoreESys;

    public void Switch()
    {
        CoreESys.SetSelectedGameObject(SwitchTo);
    }

    public void Dont()
    {
        Debug.Log("234234324234234234234");
    }
}
