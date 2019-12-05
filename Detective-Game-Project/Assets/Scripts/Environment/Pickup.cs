using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Pickup : InteractableObject
    {
        private Rigidbody rigidBody;
        [Header("If this variable is 0 then the item doesn't break.")]
        public int destroyAfterXUsages;
        [HideInInspector]
        private int timesUsed = 0;

        private void Start()
        {
            interactableType = InteractableType.Pickup;
            rigidBody = GetComponent<Rigidbody>();
        }

        public override void interact()
        {
            if (interactable)
            {
                transform.rotation = transform.rotation;
                rigidBody.isKinematic = true;
                rigidBody.useGravity = false;
                interactable = false;
            }
            else
            {
                rigidBody.isKinematic = false;
                rigidBody.useGravity = true;
                interactable = true;
            }
        }
    }
}
