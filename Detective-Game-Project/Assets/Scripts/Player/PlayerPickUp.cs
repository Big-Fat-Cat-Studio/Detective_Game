using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class PlayerPickUp : MonoBehaviour
    {
        public GameObject text;
        public ActivePlayer currentPlayer;

        new BoxCollider collider;
        GameObject holding;
        List<GameObject> pickupsInRange;

        // Start is called before the first frame update
        void Start()
        {
            pickupsInRange = new List<GameObject>();
            holding = null;
            collider = GetComponent<BoxCollider>();
            text.SetActive(false);
        }

        private void Update()
        {
            if (SwitchPlayer.active_player != currentPlayer)
            {
                if (text.activeSelf == true)
                {
                    text.SetActive(false);
                }

                return;
            }

            if (pickupsInRange.Count > 0 && text.activeSelf == false)
            {
                text.SetActive(true);
            }

            if (holding != null)
            {
                holding.transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
            }

            if (Input.GetKeyDown(KeyCode.F))
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

        void dropObject()
        {
            if (holding != null)
            {
                holding.transform.position = collider.bounds.center;
                holding.GetComponent<Rigidbody>().isKinematic = false;
                holding.GetComponent<Rigidbody>().useGravity = true;
                holding = null;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == Constant.TAG_PICKUP)
            {
                pickupsInRange.Add(other.gameObject);
                text.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == Constant.TAG_PICKUP)
            {
                pickupsInRange.Remove(other.gameObject);

                if (pickupsInRange.Count == 0)
                {
                    text.SetActive(false);
                }
            }
        }
    }
}
