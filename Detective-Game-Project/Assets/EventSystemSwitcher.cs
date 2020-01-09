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

        // From time to time the button doesn't get highlighted
        // This fixes that.
        SwitchTo.GetComponent<Button>().OnSelect(null);
    }

    public void Dont()
    {
        Debug.Log("234234324234234234234");
    }
}
