using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Scripts
{
    public class DestroyAndSpawn : InteractableObject
    {
        public GameObject neededItem;
        public GameObject itemToSpawn;
        public string afterInteractMessage;

        // Start is called before the first frame update
        void Start()
        {
            interactableType = InteractableType.Destroyable;
        }

        public void interact(ActivePlayer player, GameObject playerItem)
        {
            if (neededItem == null || ReferenceEquals(playerItem, neededItem) ||
                playerItem.name.Substring(0, playerItem.name.Length - 7) == neededItem.name)
            {
                this.gameObject.SetActive(false);
                Destroy(this.gameObject);
                if(itemToSpawn != null)
                {
                    Instantiate(itemToSpawn, this.transform.position, this.transform.rotation);
                }
            }
            else
            {
                GameManager.Instance.showAfterInteractText(player, afterInteractMessage);
            }
        }
    }
}