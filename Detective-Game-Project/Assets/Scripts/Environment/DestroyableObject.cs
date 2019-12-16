using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Scripts
{
    public class DestroyableObject : InteractableObject
    {
        public GameObject neededItem;
        public string afterInteractMessage;

        void Start()
        {
            interactableType = InteractableType.Destroyable;
        }

        public void interact(ActivePlayer player, GameObject playerItem)
        {
            if (neededItem == null || ReferenceEquals(playerItem, neededItem) || (playerItem != null &&
                playerItem.name.Substring(0, playerItem.name.Length - 7) == neededItem.name))
            {
                this.gameObject.SetActive(false);
                Destroy(this.gameObject);
            }
            else
            {
                GameManager.Instance.showAfterInteractText(player, afterInteractMessage);
            } 
        }
    }
}
