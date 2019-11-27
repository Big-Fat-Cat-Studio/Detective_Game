using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class LiftsAnObject : InteractableObject
    {
        public GameObject objectToLift;
        public float amountOfMovement;
        public float speed;
        public Direction direction;

        // Start is called before the first frame update
        void Start()
        {
            interactableType = InteractableType.LiftsAnObject;
            objectToLift.GetComponent<ObjectToLift>().addVariables(direction, amountOfMovement, speed);
        }

        private void Update()
        {
            
        }

        public void interact()
        {
            objectToLift.GetComponent<ObjectToLift>().startMoving();
        }
    }
}
