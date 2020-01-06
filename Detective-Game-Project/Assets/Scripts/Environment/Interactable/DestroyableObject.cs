using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Scripts
{
    public class DestroyableObject : InteractableObjectItemNeeded
    {
        protected override void interactSucces(ActivePlayer player, GameObject playerItem)
        {
            interactable = false;
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
