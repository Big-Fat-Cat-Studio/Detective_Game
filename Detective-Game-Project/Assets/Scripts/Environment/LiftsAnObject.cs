using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class LiftsAnObject : InteractableObject
    {
        public GameObject objectToLift;

        // Start is called before the first frame update
        void Start()
        {
            interactableType = InteractableType.Normal;
        }

        public override void interact()
        {
            objectToLift.GetComponent<ObjectToLift>().startMoving();
        }
    }
}
