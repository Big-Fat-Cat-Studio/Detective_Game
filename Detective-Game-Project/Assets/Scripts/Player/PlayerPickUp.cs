﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class PlayerPickUp : MonoBehaviour
    {
        public GameObject holding;
        public ActivePlayer currentPlayer;

        private bool showsText;
        new BoxCollider collider;
        List<GameObject> pickupsInRange;
        List<GameObject> wallsInRange;

        // Start is called before the first frame update
        void Start()
        {
            pickupsInRange = new List<GameObject>();
            wallsInRange = new List<GameObject>();
            holding = null;
            collider = GetComponent<BoxCollider>();
        }

        private void Update()
        {
            if (GameManager.Instance.ActivePlayer != currentPlayer)
            {
                if (showsText)
                {
                    GameManager.Instance.removePickupText(currentPlayer);
                    showsText = false;
                }
                
                return;
            }

            if (pickupsInRange.Count > 0 && !showsText)
            {
                GameManager.Instance.showPickupText(getClosestObject().GetComponent<Pickup>().pickupMessage, currentPlayer);
                showsText = true;
            }

            if (holding != null)
            {
                holding.transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                GameObject closestObject = getClosestObject();

                dropObject();
                if (closestObject != null)
                {
                    holding = closestObject;
                    holding.transform.rotation = transform.rotation;
                    holding.GetComponent<Rigidbody>().isKinematic = true;
                    holding.GetComponent<Rigidbody>().useGravity = false;
                }
            }
        }

        GameObject getClosestObject()
        {
            GameObject closestObject = null;

            foreach (GameObject pickup in pickupsInRange)
            {
                if (holding == null || !ReferenceEquals(pickup, holding))
                {
                    if (closestObject == null)
                    {
                        closestObject = pickup;
                        continue;
                    }

                    float distance = Vector3.Distance(pickup.transform.position, transform.position);
                    float distanceClosestObject = Vector3.Distance(closestObject.transform.position, transform.position);
                    if (distance < distanceClosestObject)
                    {
                        closestObject = pickup;
                    }
                }
            }
            return closestObject;
        }

        void dropObject()
        {
            if (holding != null)
            { 
                if (wallsInRange.Count == 0)
                {
                    holding.transform.position = collider.bounds.center;
                }
                
                holding.GetComponent<Rigidbody>().isKinematic = false;
                holding.GetComponent<Rigidbody>().useGravity = true;
                holding = null;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == Constant.TAG_PICKUP && !ReferenceEquals(holding, other.gameObject))
            {
                pickupsInRange.Add(other.gameObject);
                GameManager.Instance.showPickupText(getClosestObject().GetComponent<Pickup>().pickupMessage, currentPlayer);
                showsText = true;
            }

            if (other.gameObject.layer == Constant.LAYER_WALL)
            {
                wallsInRange.Add(other.gameObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == Constant.TAG_PICKUP)
            {
                pickupsInRange.Remove(other.gameObject);

                if (pickupsInRange.Count == 0)
                {
                    GameManager.Instance.removePickupText(currentPlayer);
                    showsText = true;
                }
            }

            if (other.gameObject.layer == Constant.LAYER_WALL)
            {
                wallsInRange.Remove(other.gameObject);
            }
        }
    }
}
