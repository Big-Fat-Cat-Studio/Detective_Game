using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Pickup : InteractableObject
    {
        [Header("Unused")]
        private new GameObject neededItem;
        [Header("Unused")]
        private new string afterInteractMessage;

        [Header("If this variable is 0 then the item doesn't break.")]
        public int destroyAfterXUsages;
        [HideInInspector]
        private int timesUsed = 0;

        private void Start()
        {
            interactableType = InteractableType.Pickup;
        }

        public void useItem()
        {
            timesUsed++;

            /*if (destroyAfterXUsages != 0 && timesUsed >= destroyAfterXUsages)
            {
                Destroy(this.gameObject);
            }*/
        }
    }
}
