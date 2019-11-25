using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts {
    public class InteractableObject : MonoBehaviour
    {
        public GameObject neededItem;
        public ActivePlayer PlayerThatCanInteract;

        [Header("\"Press [x] to ---\"")]
        public string interactMessage;
        public string afterInteractMessage;
        [HideInInspector]
        public bool interactable = true;
        public bool destroy = true;

        public virtual void interact(ActivePlayer player, GameObject playerItem)
        {
            if (player == PlayerThatCanInteract)
            {
                if (!destroy && gameObject.name.Contains("cookieDispenser"))
                {
                    gameObject.GetComponent<CookieDispenser>().Use(GameManager.Instance.Animal);
                }
                else if ((neededItem == null || ReferenceEquals(playerItem, neededItem)))
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
