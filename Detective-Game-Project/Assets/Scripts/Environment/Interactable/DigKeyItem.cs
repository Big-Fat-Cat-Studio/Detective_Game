﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class DigKeyItem : Key
    {
        public string pickUpItemText;

        // Start is called before the first frame update
        void Start()
        {
            interactableType = InteractableType.Normal;
            interactable = true;
        }

        public override void interact()
        {
            if (interactableType == InteractableType.Pickup)
            {
                pickUpItem();
            }
            else
            {
                GameManager.Instance.Animal.GetComponentInChildren<PlayerInteract>().giveItem(this.gameObject);
                interactable = false;
                interactableType = InteractableType.Pickup;
                PlayerThatCanInteract = ActivePlayer.Both;
                interactMessage = pickUpItemText;
            }
        }
    }
}