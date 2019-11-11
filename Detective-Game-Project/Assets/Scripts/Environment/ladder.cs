using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class ladder : MonoBehaviour
    {
        private void OnTriggerEnter(Collider collision)
        {
            if (ReferenceEquals(collision.gameObject, GameManager.Instance.Kid))
            {
                collision.gameObject.GetComponent<KidPlayer>().is_climbing = true;
                collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
        private void OnTriggerExit(Collider collision)
        {
            if (ReferenceEquals(collision.gameObject, GameManager.Instance.Kid))
            {
                collision.gameObject.GetComponent<KidPlayer>().is_climbing = false;
                collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}
