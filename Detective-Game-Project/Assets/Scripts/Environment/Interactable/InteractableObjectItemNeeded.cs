using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public abstract class InteractableObjectItemNeeded : InteractableObject
    {
        public GameObject neededItem;
        public string afterInteractMessage;

        void Start()
        {
            interactableType = InteractableType.ItemNeeded;
        }

        public void interact(ActivePlayer player, GameObject playerItem)
        {
            if (playerItem == null && neededItem != null)
            {
                interactFail(player, playerItem);
                return;
            }

            if (neededItem == null || ReferenceEquals(playerItem, neededItem) ||
                playerItem.name.Substring(0, playerItem.name.Length - 7) == neededItem.name)
            {
                interactSucces(player, playerItem);
            }
            else
            {
                interactFail(player, playerItem);
            }
        }

        protected abstract void interactSucces(ActivePlayer player, GameObject playerItem);

        protected virtual void interactFail(ActivePlayer player, GameObject playerItem)
        {
            GameManager.Instance.showAfterInteractText(player, afterInteractMessage);
        }
    }
}
