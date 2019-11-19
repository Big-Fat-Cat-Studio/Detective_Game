using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class PlayerInteract : MonoBehaviour
    {
        public ActivePlayer currentPlayer;
        private bool showsText;

        List<GameObject> interactableObjects;

        // Start is called before the first frame update
        void Start()
        {
            interactableObjects = new List<GameObject>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!GameManager.Instance.checkIfPlayerIsActive(currentPlayer))
            {
                if (showsText)
                {
                    GameManager.Instance.removeInteractText(currentPlayer);
                    showsText = false;
                }

                return;
            }

            if (interactableObjects.Count > 0 && !showsText)
            {
                GameManager.Instance.showInteractText(getClosestObject().GetComponent<InteractableObject>().interactMessage, currentPlayer);
                showsText = true;
            }

            if (GameManager.Instance.getButtonPressForPlayer(currentPlayer, "Interact", ButtonPress.Down))
            {
                GameObject closestInteractable = getClosestObject();            

                if (closestInteractable != null)
                {
                    closestInteractable.GetComponent<InteractableObject>().interact(currentPlayer, GetComponent<PlayerPickUp>().holding);

                    //Check if the object disappeared (probably will be different later)
                    if (closestInteractable == null || closestInteractable.activeSelf == false)
                    {
                        interactableObjects.Remove(closestInteractable);
                        if (interactableObjects.Count == 0)
                        {
                            GameManager.Instance.removeInteractText(currentPlayer);
                        }
                    }
                }
            }
        }

        /**
         * Returns the gameobject that's the closest to the player
         */
        private GameObject getClosestObject()
        {
            GameObject closestInteractable = null;

            foreach (GameObject interactable in interactableObjects)
            {
                if (closestInteractable == null)
                {
                    closestInteractable = interactable;
                    continue;
                }

                float distance = Vector3.Distance(interactable.transform.position, transform.position);
                float distanceClosestInteractable = Vector3.Distance(closestInteractable.transform.position, transform.position);
                if (distance < distanceClosestInteractable)
                {
                    closestInteractable = interactable;
                }
            }

            return closestInteractable;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == Constant.TAG_INTERACT)
            {
                interactableObjects.Add(other.gameObject);
                GameManager.Instance.showInteractText(getClosestObject().GetComponent<InteractableObject>().interactMessage, currentPlayer);
                showsText = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == Constant.TAG_INTERACT)
            {
                interactableObjects.Remove(other.gameObject);

                if (interactableObjects.Count == 0)
                {
                    GameManager.Instance.removeInteractText(currentPlayer);
                    showsText = false;
                }
            }
        }
    }
}
