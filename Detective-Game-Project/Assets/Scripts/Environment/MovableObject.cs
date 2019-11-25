using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class MovableObject : InteractableObject
    {
        [Header("Unused")]
        private new GameObject neededItem;
        [Header("Unused")]
        private new string afterInteractMessage;

        private void Start()
        {
            interactableType = InteractableType.Movable;
        }
    }
}