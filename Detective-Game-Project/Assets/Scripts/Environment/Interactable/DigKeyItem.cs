using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class DigKeyItem : Key
    {
        public string pickUpItemText;
        Animator animator;

        // Start is called before the first frame update
        void Start()
        {
            interactableType = InteractableType.Normal;
            interactable = true;
        }

        protected override void Update()
        {
            if (interactableType == InteractableType.Pickup)
            {
                base.Update();
            }
        }

        public override void interact(ActivePlayer player)
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
                GameManager.Instance.Animal.GetComponentInChildren<Animator>().SetTrigger("dig");
            }
        }
    }
}