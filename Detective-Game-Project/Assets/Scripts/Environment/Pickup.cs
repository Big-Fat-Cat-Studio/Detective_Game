using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Pickup : MonoBehaviour
    {
        [Header("Press [Z] to pick up ---")]
        public string pickupMessage;
        [Header("If this variable is 0 then the item doesn't break.")]
        public int destroyAfterXUsages;
        [HideInInspector]
        private int timesUsed = 0;

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
