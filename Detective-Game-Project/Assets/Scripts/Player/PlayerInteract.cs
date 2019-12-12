using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class PlayerInteract : MonoBehaviour
    {
        public ActivePlayer currentPlayer;
        [HideInInspector]
        public GameObject holding;
        [HideInInspector]
        public List<GameObject> smallItemsHeld;
        private bool showsText;
        private InteractableObject objectInteractedWith;
        private float holdTimer;
        List<GameObject> interactableObjects;

        // Start is called before the first frame update
        void Start()
        {
            interactableObjects = new List<GameObject>();
            smallItemsHeld = new List<GameObject>();
            objectInteractedWith = null;
            holding = null;
        }

        // Update is called once per frame
        void Update()
        {
            if (objectInteractedWith != null && objectInteractedWith.interactableType == InteractableType.Pickup)
            {
                holdTimer += Time.deltaTime;
            }

            if (holding != null)
            {
                holding.transform.rotation = transform.rotation;
                holding.transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
            }

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
        }

        public void stopInteract(){
            objectInteractedWith = null;
        }

        public void interact(bool buttonReleased)
        {
            if (objectInteractedWith != null && buttonReleased)
            {
                InteractableObject objectInteractedWith = this.objectInteractedWith;
                this.objectInteractedWith = null;
                if (ReferenceEquals(objectInteractedWith.gameObject, holding) && holdTimer > 1f)
                {
                    throwObject();
                    holdTimer = 0f;
                    return;
                }

                holdTimer = 0f;

                if (objectInteractedWith.interactableType == InteractableType.HoldButton)
                {
                    if (objectInteractedWith is MovableObject)
                    {
                        ((MovableObject)objectInteractedWith).interact(currentPlayer);
                    }
                    else
                    {
                        objectInteractedWith.GetComponent<InteractableObject>().interact();
                    }
                    return;
                }
            }

            GameObject closestInteractable = getClosestObject();

            if (closestInteractable != null)
            {
                InteractableObject interactableObject = closestInteractable.GetComponent<InteractableObject>();

                if (!buttonReleased)
                {
                    if (interactableObject.interactableType == InteractableType.HoldButton)
                    {
                        if (interactableObject is MovableObject)
                        {
                            ((MovableObject)interactableObject).interact(currentPlayer);
                        }
                        else
                        {
                            interactableObject.interact();
                        }
                        objectInteractedWith = interactableObject;
                    }
                }
                else if (interactableObject.interactableType == InteractableType.Pickup)
                {
                    if (interactableObject is Key && currentPlayer == ActivePlayer.Human)
                    {
                        holdKey(closestInteractable);
                    }
                    else
                    {
                        giveItem(closestInteractable);
                        holding.GetComponent<InteractableObject>().interact();
                    }
                }
                else
                {
                    if (interactableObject.interactableType == InteractableType.Destroyable)
                    {
                        ((DestroyableObject)interactableObject).interact(currentPlayer, holding);
                    }
                    else if (interactableObject.interactableType != InteractableType.HoldButton)
                    {
                        interactableObject.interact();
                    }

                    //Check if the object disappeared or if the player can't interact with it anymore
                    if (closestInteractable == null || closestInteractable.activeSelf == false || !interactableObject.interactable)
                    {
                        interactableObjects.Remove(closestInteractable);
                        destroyObject();
                    }
                }
            }
            else if (buttonReleased)
            {
                dropObject();
            }
            else if (holding != null)
            {
                objectInteractedWith = holding.GetComponent<InteractableObject>();
            }

            if (countObjectsInRange() == 0)
            {
                GameManager.Instance.removeInteractText(currentPlayer);
                showsText = false;
            }
        }

        public void giveItem(GameObject item)
        {
            dropObject();
            holding = item;
            interactableObjects.Remove(item);
        }

        public void throwObject()
        {
            if (holding != null)
            {
                holding.GetComponent<InteractableObject>().interact();
                holding.transform.rotation = transform.rotation;
                Rigidbody holdingRigidBody = holding.GetComponent<Rigidbody>();
                holdingRigidBody.AddRelativeForce(new Vector3(0f, holdingRigidBody.mass * 100, holdingRigidBody.mass * 500));
                holding = null;
            }
        }

        public void removeHoldingObject()
        {
            interactableObjects.Remove(holding);
            holding = null;
        }

        void holdKey(GameObject keyObject)
        {
            keyObject.SetActive(false);
            smallItemsHeld.Add(keyObject);
            Key key = keyObject.GetComponent<Key>();

            if (smallItemsHeld.Count >= key.amountNeeded)
            {
                for (int i = smallItemsHeld.Count - 1; i >= 0; i--)
                {
                    if (smallItemsHeld[i].GetComponent<InteractableObject>() is Key)
                    {
                        smallItemsHeld.RemoveAt(i);
                    }
                }

                GameManager.Instance.showAfterInteractText(currentPlayer, key.fullItemText);
                GameObject newItem = Instantiate(key.fullItem);
                holding = newItem;
                holding.GetComponent<Pickup>().interact();
                interactableObjects.Remove(holding);
            }
            else
            {
                GameManager.Instance.showAfterInteractText(currentPlayer, key.getFullAfterInteractText(smallItemsHeld.Count));
            }

            interactableObjects.Remove(keyObject);
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
                holding.GetComponent<InteractableObject>().interact();
                holding = null;
            }
        }

        void destroyObject()
        {
            if (holding != null && holding.GetComponent<Pickup>().breakOnUse)
            {
                Destroy(holding);
                holding = null;
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
                && other.gameObject.GetComponent<InteractableObject>().interactable
                && (other.gameObject.GetComponent<InteractableObject>().PlayerThatCanInteract == currentPlayer
                    || other.gameObject.GetComponent<InteractableObject>().PlayerThatCanInteract == ActivePlayer.Both))
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

                if (interactableObjects.Contains(null))
                {
                    interactableObjects.Remove(null);
                }

                if (countObjectsInRange() == 0)
                {
                    GameManager.Instance.removeInteractText(currentPlayer);
                    showsText = false;
                }
                else
                {
                    GameManager.Instance.showInteractText(getClosestObject().GetComponent<InteractableObject>().interactMessage, currentPlayer);
                }


                if (other.gameObject.GetComponent<InteractableObject>() is MovableObject && this.gameObject.GetComponentInParent<Player>().canPushPull) 
                {
                    this.gameObject.GetComponentInParent<Player>().move = true;
                    other.gameObject.GetComponent<MovableObject>().interact(currentPlayer);
                    stopInteract();
                }
            }
        }
    }
}
