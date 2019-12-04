using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class EndLevel : InteractableObject
    {
        //Variables


        //Unity functions
        void Start()
        {
            interactableType = InteractableType.EndLevel;
        }

        //Custom functions
        public void interact(ActivePlayer player, GameObject playerItem)
        {

        }
    }
}