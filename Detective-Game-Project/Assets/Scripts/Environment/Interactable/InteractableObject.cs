using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts {
    public abstract class InteractableObject : MonoBehaviour
    {
        public ActivePlayer PlayerThatCanInteract;
        [Header("\"Press [x] to ---\"")]
        public string interactMessage;

        [HideInInspector]
        public bool interactable = true;
        [HideInInspector]
        public InteractableType interactableType;
        public bool isHoldPrompt = false;

        public virtual void interact(ActivePlayer player)
        {
        }
    }
}
