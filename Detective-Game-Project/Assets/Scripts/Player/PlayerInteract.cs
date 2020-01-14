using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class PlayerInteract : MonoBehaviour
    {
        public ActivePlayer currentPlayer;
        public AudioClip cry;
        [HideInInspector]
        public GameObject holding;
        [HideInInspector]
        public List<GameObject> smallItemsHeld;
        private bool showsText;
        private InteractableObject objectInteractedWith;
        private float holdTimer;
        List<GameObject> interactableObjects;
        public Transform holdingPoint;

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
                holding.transform.rotation = holdingPoint.rotation; //rotation must be fixed
                holding.transform.position = holdingPoint.position;
                holding.GetComponent<Collider>().isTrigger = true;
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
                InteractableObject interactableObject = getClosestObject().GetComponent<InteractableObject>();
                GameManager.Instance.showInteractText(interactableObject.interactMessage, currentPlayer, interactableObject.isHoldPrompt);
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
                if (currentPlayer == ActivePlayer.Human && ReferenceEquals(objectInteractedWith.gameObject, holding) && holdTimer > 1f)
                {
                    throwObject();
                    holdTimer = 0f;
                    return;
                }

                holdTimer = 0f;

                if (objectInteractedWith.interactableType == InteractableType.HoldButton)
                {
                    objectInteractedWith.GetComponent<InteractableObject>().interact(currentPlayer);
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
                        interactableObject.interact(currentPlayer);
                        if (interactableObject is MovableObject)
                        {
                            GetComponentInParent<Player>().move = true;
                        }
                        objectInteractedWith = interactableObject;
                    }
                }
                else if (interactableObject.interactableType == InteractableType.Pickup)
                {
                    if ((interactableObject is Key || interactableObject is DigKeyItem) && currentPlayer == ActivePlayer.Human)
                    {
                        holdKey(closestInteractable);
                    }
                    else
                    {
                        giveItem(closestInteractable);
                        holding.GetComponent<InteractableObject>().interact(currentPlayer);
                    }
                }
                else
                {
                    if (interactableObject.interactableType == InteractableType.ItemNeeded || interactableObject.interactableType == InteractableType.DEBUG)
                    {
                        ((InteractableObjectItemNeeded)interactableObject).interact(currentPlayer, holding);
                    }
                    else if (interactableObject.interactableType != InteractableType.HoldButton)
                    {
                        interactableObject.interact(currentPlayer);
                    }

                    //Check if the object disappeared or if the player can't interact with it anymore
                    if (closestInteractable == null || closestInteractable.activeSelf == false || !interactableObject.interactable)
                    {
                        interactableObjects.Remove(closestInteractable);
                        destroyHoldingObject();
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
            else if (currentPlayer == ActivePlayer.Animal)
            {
                GetComponentInParent<AudioSource>().clip = cry;
                GetComponentInParent<AudioSource>().Play();
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
            item.GetComponentInChildren<ParticleSystem>().Stop(); //particles
        }

        public void throwObject()
        {
            if (holding != null)
            {
                holding.GetComponent<Collider>().isTrigger = false;
                holding.GetComponent<InteractableObject>().interact(currentPlayer);
                holding.GetComponentInChildren<ParticleSystem>().Play(); //particles
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

                GameManager.Instance.showAfterInteractText(currentPlayer, key.combineIntoFullItemText);
                GameObject newItem = Instantiate(key.fullItem);
                holding = newItem;
                holding.GetComponent<Pickup>().interact(currentPlayer);
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
                holding.GetComponent<Collider>().isTrigger = false;
                holding.GetComponent<InteractableObject>().interact(currentPlayer);
                holding.GetComponentInChildren<ParticleSystem>().Play(); //particles
                holding = null;
            }
        }

        public void destroyHoldingObject()
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
                && !interactableObjects.Contains(other.gameObject)
                && (other.gameObject.GetComponent<InteractableObject>().PlayerThatCanInteract == currentPlayer
                    || other.gameObject.GetComponent<InteractableObject>().PlayerThatCanInteract == ActivePlayer.Both))
            {
                interactableObjects.Add(other.gameObject);
                InteractableObject interactableObject = getClosestObject().GetComponent<InteractableObject>();
                GameManager.Instance.showInteractText(interactableObject.interactMessage, currentPlayer, interactableObject.isHoldPrompt);
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
                    InteractableObject interactableObject = getClosestObject().GetComponent<InteractableObject>();
                    GameManager.Instance.showInteractText(interactableObject.interactMessage, currentPlayer, interactableObject.isHoldPrompt);
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
