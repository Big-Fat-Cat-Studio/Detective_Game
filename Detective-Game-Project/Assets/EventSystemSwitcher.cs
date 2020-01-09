using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EventSystemSwitcher : MonoBehaviour
{
    private EventSystem _CoreESys;

    public GameObject SwitchTo;


    public void Switch()
    {
        _CoreESys = EventSystem.current;
        _CoreESys.SetSelectedGameObject(SwitchTo);
    }

    public void Dont()
    {
        Debug.Log("234234324234234234234");
    }
}
