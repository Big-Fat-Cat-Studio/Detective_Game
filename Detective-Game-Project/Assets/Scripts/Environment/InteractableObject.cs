using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts {
    public class InteractableObject : MonoBehaviour
    {
        public GameObject neededItem;
        [Header("\"Press [x] to ---\"")]
        public string interactMessage;
        public string afterInteractMessage;

        public void interact(ActivePlayer player, GameObject playerItem)
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
