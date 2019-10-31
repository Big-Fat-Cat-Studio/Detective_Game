using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    public class Door : MonoBehaviour
    {
        public GameObject text;
        public string interact_text;

        private bool can_interact = false;

        private void Start()
        {
            text.SetActive(false);
            text.GetComponent<Text>().text = interact_text;
        }
        private void Update()
        {
            if (can_interact && Input.GetKeyDown(KeyCode.X))
            {
                text.SetActive(false);
                Destroy(this.gameObject);
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Kid" || other.gameObject.tag == "Grandpa")
            {
                can_interact = true;
                text.SetActive(true);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Kid" || other.gameObject.tag == "Grandpa")
            {
                can_interact = false;
                text.SetActive(false);
            }
        }
    }
}