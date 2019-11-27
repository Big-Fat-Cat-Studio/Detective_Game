using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class MovableObject : InteractableObject
    {
        private void Start()
        {
            interactableType = InteractableType.Movable;
        }
    }
}