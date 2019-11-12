using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class PlayerInteract : MonoBehaviour
    {
        public GameObject text;
        public ActivePlayer currentPlayer;

        new BoxCollider collider;
        List<GameObject> interactableObjects;

        // Start is called before the first frame update
        void Start()
        {
            interactableObjects = new List<GameObject>();
            text.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.Instance.ActivePlayer != currentPlayer)
            {
                if (text.activeSelf == true)
                {
                    text.SetActive(false);
                }

                return;
            }

            if (interactableObjects.Count > 0 && text.activeSelf == false)
            {
                text.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                GameObject closestInteractable = null;

                //Check which object is closest to the player
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

                if (closestInteractable != null)
                {
                    closestInteractable.GetComponent<InteractableObject>().interact(GetComponent<PlayerPickUp>().holding);

                    //Check if the object disappeared (probably will be different later)
                    if (closestInteractable == null || closestInteractable.activeSelf == false)
                    {
                        interactableObjects.Remove(closestInteractable);
                        if (interactableObjects.Count == 0)
                        {
                            text.SetActive(false);
                        }
                    }
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == Constant.TAG_INTERACT)
            {
                interactableObjects.Add(other.gameObject);
                text.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == Constant.TAG_INTERACT)
            {
                interactableObjects.Remove(other.gameObject);

                if (interactableObjects.Count == 0)
                {
                    text.SetActive(false);
                }
            }
        }
    }
}
