using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class LiftsAnObject : InteractableObject
    {
        public GameObject objectToLift;
        public bool CheckStates;
        // Add ObjectState script to each of these objects
        // Add "InteractState State = InteractState.[STATUS]" to said script
        // If InteractState State = InteractState.ACTIVATED" -> allow interaction
        [Tooltip("Each object is required to have the enum XENUM")]
        public GameObject[] RequiredStates;
        [Header("Only used when CheckStates is used")]
        public string afterInteractText;

        private int CheckedNum;

        void Start()
        {
            interactableType = InteractableType.Normal;
        }

        public override void interact(ActivePlayer player)
        {
            if (CheckStates)
            {
                CheckedNum = 0;
                // Check if each state is active.
                foreach (GameObject state in RequiredStates)
                    if (state.GetComponent<ObjectState>().State == InteractState.ACTIVATED)
                        CheckedNum += 1;
                // If the number of ACTIVATES == the number of objects in need
                // of activation -> only then run the interaction.
                if (RequiredStates.Length == CheckedNum)
                {
                    objectToLift.GetComponent<ObjectToLift>().startMoving();
                }
                else
                {
                    GameManager.Instance.showAfterInteractText(player, afterInteractText);
                }
            }
            else
            {
                objectToLift.GetComponent<ObjectToLift>().startMoving();
            }
        }
    }
}
