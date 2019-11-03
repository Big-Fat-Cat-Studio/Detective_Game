using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    public class Door : MonoBehaviour
    {
        public GameObject text;
        public bool locked;
        //public string interact_text;
        public string after_interact_text;

        private bool can_interact = false;

        private void Start()
        {
            text.SetActive(false);
        }
        private void Update()
        {
            if (can_interact && Input.GetKeyDown(KeyCode.X))
            {
                if (locked)
                {
                    text.GetComponent<Text>().text = after_interact_text;
                    StartCoroutine(textDissappear());
                }
                else
                {
                    text.SetActive(false);
                    Destroy(this.gameObject);
                }
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Kid" || other.gameObject.tag == "Grandpa")
            {
                can_interact = true;

                if (text.GetComponent<Text>().text != after_interact_text)
                {
                    text.GetComponent<Text>().text = Constant.TEXT_DOOR;
                }

                text.SetActive(true);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Kid" || other.gameObject.tag == "Grandpa")
            {
                can_interact = false;

                if (text.GetComponent<Text>().text == Constant.TEXT_DOOR)
                {
                    text.SetActive(false);
                }
            }
        }

        IEnumerator textDissappear()
        {
            yield return new WaitForSecondsRealtime(6);
            if (text.GetComponent<Text>().text == after_interact_text)
            {
                text.GetComponent<Text>().text = "";
                text.SetActive(false);
            }
        }
    }
}