using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class CookieDispenser : InteractableObject
    {
        public float cooldown = 10f;
        public float timer = 0f;

        private void Start()
        {
            interactableType = InteractableType.Normal;
        }

        void Update()
        {
            if(interactable) return;

            if (timer < cooldown)
            {
                timer += Time.deltaTime;
            }
            else
            {
                interactable = true;
                timer = 0f;
            }
        }

        public override void interact()
        {
            if(!interactable) return;

            interactable = false;
            GameManager.Instance.Animal.GetComponent<AnimalPlayer>().boostTimer = 5f;
        }
    }
}
