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

    // These are called twice (start/finish)
    public void OnMOVE(InputAction.CallbackContext context)
    {
    }

    public void OnSUBMIT(InputAction.CallbackContext context)
    {
    }

    public void OnRETURN(InputAction.CallbackContext context)
    {
    }

    public void OnESCAPE(InputAction.CallbackContext context)
    {
        
    }
}
