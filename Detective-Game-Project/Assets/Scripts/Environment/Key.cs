using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Key : Pickup
    {
        public int amountNeeded;
        public GameObject fullItem;
        public string afterInteractText;
        public string fullItemText;

        public string getFullAfterInteractText(int amountNow)
        {
            return afterInteractText + " " + amountNow + "/" + amountNeeded;
        }
    }
}
