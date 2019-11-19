using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Button : MonoBehaviour
    {
        //Variables
        public GameObject target;

        //Unity functions
        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.tag == "Grandpa")//nog aanpassen naar correcte player tag
            {
                target.GetComponent<ButtonTarget>().Activate();
            }
        }
    }
}