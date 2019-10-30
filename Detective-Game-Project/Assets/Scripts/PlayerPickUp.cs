using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    GameObject holding;
    List<GameObject> pickupsInRange;

    // Start is called before the first frame update
    void Start()
    {
        pickupsInRange = new List<GameObject>();
        holding = null;
    }

    private void Update()
    {
        if (holding != null)
        {
            holding.transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            foreach (GameObject pickup in pickupsInRange)
            {
                //NEED AN IF STATEMENT HERE ABOUT THE CAMERA POINTING/MOUSE POINTING AT THE RIGHT OBJECT
                if (holding == null || !ReferenceEquals(pickup, holding))
                {
                    dropObject();

                    holding = pickup;
                    holding.transform.rotation = transform.rotation;
                    holding.GetComponent<Rigidbody>().isKinematic = true;
                    holding.GetComponent<Rigidbody>().useGravity = false;
                    return;
                }
            }

            dropObject();
        }
    }

    void dropObject()
    {
        if (holding != null)
        {
            //obviously temporary position, need to know more about the camera before items can be dropped properly
            holding.transform.position = new Vector3(this.transform.position.x + 1f, this.transform.position.y, this.transform.position.z);
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
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == Constant.TAG_PICKUP)
        {
            pickupsInRange.Remove(other.gameObject);
        }
    }
}
