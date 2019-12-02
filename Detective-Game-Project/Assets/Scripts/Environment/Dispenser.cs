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
            Debug.Log("using");

            GameManager.Instance.Animal.GetComponent<AnimalPlayer>().boostTimer = 3f;
            timer = cooldown;
        }

        void Update()
        {
            if(timer == 0f) return;

            if(timer <= 0f)
            {
                timer = 0f;
            }
            else
            {
                timer -= Time.deltaTime;
            }

        }
    }
}
