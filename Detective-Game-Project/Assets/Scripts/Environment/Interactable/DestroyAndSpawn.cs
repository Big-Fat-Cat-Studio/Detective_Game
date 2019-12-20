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

        // TODO(HAMZA): Change to DONTDESTROYBUTSPAWN
        public bool DEBUG;
        public bool Consumed;

        // Start is called before the first frame update
        void Start()
        {
            if (DEBUG)
                interactableType = InteractableType.DEBUG;
            else
                interactableType = InteractableType.Destroyable;
        }

        public void interact(ActivePlayer player, GameObject playerItem)
        {
            if (neededItem == null || ReferenceEquals(playerItem, neededItem) ||
                playerItem.name.Substring(0, playerItem.name.Length - 7) == neededItem.name)
            {
                if (!DEBUG)
                {
                    this.gameObject.SetActive(false);
                    Destroy(this.gameObject);
                    Instantiate(itemToSpawn, this.transform.position, this.transform.rotation);
                } else
                {
                    if (!Consumed) { 
                        Instantiate(itemToSpawn, (this.transform.position + new Vector3(0,.2f, -2)), this.transform.rotation);
                        Consumed = true;
                    }
                }
            }
            else
            {
                GameManager.Instance.showAfterInteractText(player, afterInteractMessage);
            }
        }
    }
}