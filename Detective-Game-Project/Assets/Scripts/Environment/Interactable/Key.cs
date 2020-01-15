using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Key : Pickup
    {
        public int amountNeeded;
        public GameObject fullItem;
        public string humanKeyPickUpText;
        public string combineIntoFullItemText;

        public string getFullAfterInteractText(int amountNow)
        {
            return humanKeyPickUpText + " " + amountNow + "/" + amountNeeded;
        }

        protected override void pickUpItem() {
            base.pickUpItem();
            //gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
