using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class PlayerInteract : MonoBehaviour
    {
        public ActivePlayer currentPlayer;
        public GameObject holding;

        private bool showsText;
        private float timePickupKeyHeld;

        List<GameObject> interactableObjects;

        // Start is called before the first frame update
        void Start()
        {
            interactableObjects = new List<GameObject>();
        }

        // Update is called once per frame
        void Update()
        {
            //Remove the text when the player is not active anymore
            if (!GameManager.Instance.checkIfPlayerIsActive(currentPlayer))
            {
                if (showsText)
                {
                    GameManager.Instance.removeInteractText(currentPlayer);
                    showsText = false;
                }

                return;
            }

            //Show the text again when the player is active
            if (countObjectsInRange() > 0 && !showsText)
            {
                GameManager.Instance.showInteractText(getClosestObject().GetComponent<InteractableObject>().interactMessage, currentPlayer);
                showsText = true;
            }

            //Make the held object follow the player
            if (holding != null)
            {
                holding.transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
                holding.transform.rotation = this.transform.rotation;

                //Checks how long the human held the interact button, but it's only relevant when the human holds an item.
                if (currentPlayer == ActivePlayer.Human && GameManager.Instance.getButtonPressForPlayer(currentPlayer, "Interact", ButtonPress.Press))
                {
                    timePickupKeyHeld += Time.deltaTime;
                }
            }

            if (GameManager.Instance.getButtonPressForPlayer(currentPlayer, "Interact", ButtonPress.Up))
            {
                if (timePickupKeyHeld > 1)
                {
                    throwObject();
                    return;
                }

                GameObject closestInteractable = getClosestObject();

                if (closestInteractable != null)
                {
                    InteractableObject interactableObject = closestInteractable.GetComponent<InteractableObject>();

                    if (interactableObject.interactableType == InteractableType.Unlockable)
                    {
                        interactableObject.interact(currentPlayer, holding);

                        //Check if the object disappeared or if the player can't interact with it anymore
                        if (closestInteractable == null || closestInteractable.activeSelf == false || !interactableObject.interactable)
                        {
                            interactableObjects.Remove(closestInteractable);
                        }
                    }
                    else if (interactableObject.interactableType == InteractableType.Pickup)
                    {
                        dropObject();
                        holding = closestInteractable;
                        holding.transform.rotation = transform.rotation;
                        holding.GetComponent<Rigidbody>().isKinematic = true;
                        holding.GetComponent<Rigidbody>().useGravity = false;
                        interactableObjects.Remove(closestInteractable);
                    }
                }
                else
                {
                    dropObject();
                }

                if (countObjectsInRange() == 0)
                {
                    GameManager.Instance.removeInteractText(currentPlayer);
                    showsText = false;
                }

                timePickupKeyHeld = 0f;
            }
        }

        public void removeHoldingObject()
        {
            interactableObjects.Remove(holding);
            holding = null;
        }

        int countObjectsInRange()
        {
            int count = 0;

            foreach (GameObject pickup in interactableObjects)
            {
                if (holding == null || !ReferenceEquals(pickup, holding))
                {
                    count++;
                }
            }
            return count;
        }

        void dropObject()
        {
            if (holding != null)
            {
                holding.GetComponent<Rigidbody>().isKinematic = false;
                holding.GetComponent<Rigidbody>().useGravity = true;
                holding = null;
            }
        }

        void throwObject()
        {
            if (holding != null)
            {
                Rigidbody holdingRigidBody = holding.GetComponent<Rigidbody>();
                holdingRigidBody.isKinematic = false;
                holdingRigidBody.useGravity = true;
                holdingRigidBody.AddRelativeForce(new Vector3(0f, holdingRigidBody.mass * 100, holdingRigidBody.mass * 500));
                holding = null;
                timePickupKeyHeld = 0f;
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
            if (other.gameObject.tag == Constant.TAG_INTERACT 
                && !ReferenceEquals(other.gameObject, holding)
                && (other.gameObject.GetComponent<InteractableObject>().PlayerThatCanInteract == currentPlayer
                    || other.gameObject.GetComponent<InteractableObject>().PlayerThatCanInteract == ActivePlayer.Both) 
                && other.gameObject.GetComponent<InteractableObject>().interactable)
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

                if (countObjectsInRange() == 0)
                {
                    GameManager.Instance.removeInteractText(currentPlayer);
                    showsText = false;
                }
                else
                {
                    GameManager.Instance.showInteractText(getClosestObject().GetComponent<InteractableObject>().interactMessage, currentPlayer);
                }
            }
        }
    }
}
