using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts
{
    public class TutorialItem : MonoBehaviour, InputSettings.IHumanActions
    {
        public GameObject tutorialtrigger;
        public bool done = false;

        public void OnCameraMove(InputAction.CallbackContext context)
        {
            //
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            //
        }

        public void OnInteractHold(InputAction.CallbackContext context)
        {
            print("na");
            this.gameObject.SetActive(false);
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            print("ni");
            this.gameObject.SetActive(false);
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            //
        }

        public void OnSpecial(InputAction.CallbackContext context)
        {
            //
        }

        public void OnSpecial2(InputAction.CallbackContext context)
        {
            //
        }

        public void OnSpecial3(InputAction.CallbackContext context)
        {
            //
        }

        public void OnSwap(InputAction.CallbackContext context)
        {
            //
        }
    }
}