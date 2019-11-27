using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class DestroyableObject : InteractableObject
    {
        public GameObject neededItem;
        public string afterInteractMessage;

        // Start is called before the first frame update
        void Start()
        {
            interactableType = InteractableType.Destroyable;
        }

        public void interact(ActivePlayer player, GameObject playerItem)
        {
            if (player == PlayerThatCanInteract)
            {
                if (neededItem == null || ReferenceEquals(playerItem, neededItem))
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
}
