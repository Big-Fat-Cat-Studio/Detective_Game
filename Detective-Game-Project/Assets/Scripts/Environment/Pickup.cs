using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Pickup : MonoBehaviour
    {
        [Header("Press [Z] to pick up ---")]
        public string pickupMessage;
        public string pickupType;

        public void interact(GameObject player)
        {
            gameObject.transform.rotation = player.transform.rotation;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<Rigidbody>().useGravity = false;

            switch(pickupType)
            {
                case "plank":
                    Debug.Log("plank");
                    break;
                case "inventory":
                    Debug.Log("inventory");
                    break;
                case "dog":
                    Debug.Log("dog");
                    break;
                default:
                    Debug.Log("default");
                    break;
            }
        }
    }
}
