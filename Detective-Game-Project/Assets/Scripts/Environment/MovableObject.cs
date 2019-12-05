using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class MovableObject : InteractableObject
    {
        private Rigidbody rigidBody;
        private bool pushing;

        private void Start()
        {
            interactableType = InteractableType.HoldButton;
            rigidBody = GetComponent<Rigidbody>();
        }

        public void interact(ActivePlayer player)
        {
            GameObject playerObject;

            if(player == ActivePlayer.Human)
            {
                playerObject = GameManager.Instance.Human;
            }
            else
            {
                playerObject = GameManager.Instance.Animal;
            }

            playerObject.GetComponent<Player>().togglePush();

            if (pushing)
            {
                gameObject.transform.parent = null;
            }
            else
            {
                gameObject.transform.parent = playerObject.transform;
            }

            pushing = !pushing;
            
            //rigidBody.gameObject.transform.Translate(moveDirection.x * Time.deltaTime, 0.0f, moveDirection.z * Time.deltaTime);
        }
    }
}