using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class ButtonDoor : MonoBehaviour, ButtonTarget
    {
        //Variables
        private bool isActive = true;

        //Custom functions
        public void Activate()
        {
            this.gameObject.SetActive(!isActive);
            isActive = !isActive;
            print("door has been activated");
        }
    }
}