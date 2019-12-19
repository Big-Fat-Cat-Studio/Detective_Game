using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts {
    public class DigItem : Pickup
    {
        public string pickUpItemText;
        private bool originalBreakOnUse;

        // Start is called before the first frame update
        void Start()
        {
            interactableType = InteractableType.Normal;
            interactable = true;
            originalBreakOnUse = breakOnUse;
            breakOnUse = false;
        }

        public override void interact()
        {
            if (interactableType == InteractableType.Pickup)
            {
                breakOnUse = originalBreakOnUse;
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