using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class CookieDispenser : MonoBehaviour
    {
        public float cooldown = 10f;
        bool available = true;
        
        public float timer = 0f;

        void Update()
        {
            if(available) return;

            if (timer < cooldown)
            {
                timer += Time.deltaTime;
            }
            else
            {
                available = true;
                timer = 0f;
            }
        }

        public void Use(GameObject animal)
        {
            if(!available) return;

            available = false;
            animal.GetComponent<AnimalPlayer>().boostTimer = 5f;
        }
    }
}
