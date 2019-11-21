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
            if(other.gameObject.tag == "Human" || other.gameObject.tag == "Dog")
            {
                this.playerCounter += 1;
                if(other.gameObject.tag == "Dog")
                {
                    this.dog = other.gameObject;
                }
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Human" || other.gameObject.tag == "Dog")
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