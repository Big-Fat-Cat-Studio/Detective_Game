using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Dispenser : InteractableObject
    {
        public float cooldown;
        private float timer = 0f;

        // Start is called before the first frame update
        void Start()
        {
            interactableType = InteractableType.Normal;
        }

        public override void interact()
        {
            if(timer > 0) return;

            GameManager.Instance.Animal.GetComponent<AnimalPlayer>().activateAbilityTimer("speedBoost");
            timer = cooldown;
        }

        void Update()
        {
            if(timer == 0f) return;

            timer = Math.Max(0f, timer - Time.deltaTime);
        }
    }
}
