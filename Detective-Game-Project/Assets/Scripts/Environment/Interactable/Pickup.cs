﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Pickup : InteractableObject
    {
        private Rigidbody rigidBody;
        public bool breakOnUse;

        private void Awake()
        {
            interactableType = InteractableType.Pickup;
            rigidBody = GetComponent<Rigidbody>();
        }

        public override void interact(ActivePlayer player)
        {
            pickUpItem();
        }

        protected void pickUpItem()
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
