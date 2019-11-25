using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts {
    public class InteractableObject : MonoBehaviour
    {
        public ActivePlayer PlayerThatCanInteract;

        [Header("\"Press [x] to ---\"")]
        public string interactMessage;
        public GameObject neededItem;
        public string afterInteractMessage;

        [HideInInspector]
        public bool interactable = true;
        [HideInInspector]
        public InteractableType interactableType = InteractableType.Unlockable;

        public virtual void interact(ActivePlayer player, GameObject playerItem)
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
