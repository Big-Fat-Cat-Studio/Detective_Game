using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class LiftDog : MonoBehaviour
    {
        //Variables
        public GameObject targetPosition;

        private GameObject dog;
        private int playerCounter = 0;

        //Unity functions
        private void OnTriggerEnter(Collider other)
        {
            if(ReferenceEquals(other.gameObject, GameManager.Instance.Human))
            {
                this.playerCounter += 1;
            }
            else if (ReferenceEquals(other.gameObject, GameManager.Instance.Animal))
            {
                this.playerCounter += 1;
                this.dog = other.gameObject;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (ReferenceEquals(GameManager.Instance.Animal, other.gameObject) || ReferenceEquals(GameManager.Instance.Human, other.gameObject))
            {
                this.playerCounter -= 1;
            }
        }
        private void FixedUpdate()
        {
            if (this.playerCounter == 2 && Input.GetKeyDown(KeyCode.X))
            {
                this.dog.gameObject.GetComponent<CharacterController>().enabled = false;
                this.dog.transform.position = this.targetPosition.transform.position;
                this.playerCounter -= 1;
                this.dog.gameObject.GetComponent<CharacterController>().enabled = true;
            }
        }
    }
}