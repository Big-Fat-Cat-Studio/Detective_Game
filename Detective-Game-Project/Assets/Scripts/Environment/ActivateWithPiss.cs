using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class ActivateWithPiss : MonoBehaviour, IActivateWithPiss
    {
        public Color color;

        public void Activation()
        {
            this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", color);
        }
    }
}