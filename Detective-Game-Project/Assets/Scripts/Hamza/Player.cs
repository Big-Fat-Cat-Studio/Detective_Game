using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Player : MonoBehaviour
    {
        public float speed = 2.0f;
        public float rotationSpeed = 100.0f;
        public ActivePlayer activePlayer;

        void Update()
        {
            if (SwitchPlayer.active_player == activePlayer)
            {
                float translation = Input.GetAxis("Vertical") * speed;
                float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

                translation *= Time.deltaTime;
                rotation *= Time.deltaTime;

                transform.Translate(0, 0, translation);
                transform.Rotate(0, rotation, 0);
            }
        }
    }
}