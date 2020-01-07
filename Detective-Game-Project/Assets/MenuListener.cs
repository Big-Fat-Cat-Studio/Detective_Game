using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static InputSettings;

public class MenuListener : MonoBehaviour, IUIActions
{
    [SerializeField] InputSettings Manager;

    private void Awake()
    {
        Manager = new InputSettings();
        Manager.UI.SetCallbacks(this);
    }

    private void OnEnable()
    {
        Manager.UI.Enable();
    }

    private void OnDisable()
    {
        Manager.UI.Disable();
    }

    public void OnMOVE(InputAction.CallbackContext context)
    {
        Debug.Log("MOVE");
    }

    public void OnSUBMIT(InputAction.CallbackContext context)
    {
        Debug.Log("SUBMIT");
    }
}
