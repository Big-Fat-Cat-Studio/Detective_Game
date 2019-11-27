using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts {
    public class SprinklerPuzzle : InteractableObject
    {
        public GameObject neededItem;
        public string afterInteractMessage;

        public bool solved = false;
        public int placed = 0;
        public void interact(ActivePlayer player, GameObject playerItem)
        {
            if (neededItem == null || ReferenceEquals(playerItem, neededItem))
            {
                if (playerItem.name == "PuzzleElement1")
                {
                    playerItem.transform.localPosition = new Vector3(4.5f, 0, 0);
                    ActivateSprinkler.instance.placed += 1;
                }
                if (playerItem.name == "PuzzleElement2")
                {
                    playerItem.transform.localPosition = new Vector3(7, 0, -2);
                    ActivateSprinkler.instance.placed += 1;
                }
                if (playerItem.name == "PuzzleElement3")
                {
                    playerItem.transform.localPosition = new Vector3(8, 0, 0.75f);
                    ActivateSprinkler.instance.placed += 1;
                }
                if (playerItem.name == "PuzzleElement4")
                {
                    playerItem.transform.localPosition = new Vector3(6, 0, 2.75f);
                    ActivateSprinkler.instance.placed += 1;
                }
                if (playerItem.name == "PuzzleElement5")
                {
                    playerItem.transform.localPosition = new Vector3(8.25f, 0, 1.5f);
                    ActivateSprinkler.instance.placed += 1;
                }
                GameManager.Instance.Human.GetComponentInChildren<PlayerInteract>().removeHoldingObject();
                playerItem.GetComponent<BoxCollider>().enabled = false;
                playerItem.transform.localRotation = Quaternion.identity;
                playerItem.tag = "Untagged";
                interactable = false;
            }
            else
            {
                GameManager.Instance.showAfterInteractText(player, afterInteractMessage);
            }
        }
    }
}
