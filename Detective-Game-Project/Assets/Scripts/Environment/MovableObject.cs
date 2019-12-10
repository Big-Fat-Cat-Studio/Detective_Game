using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class MovableObject : InteractableObject
    {
        private Rigidbody rigidBody;
        private bool pushing;
        private GameObject playerObject;
        private Vector3 pushforce;

        public bool both;

        private void Start()
        {
            interactableType = InteractableType.HoldButton;
            rigidBody = GetComponent<Rigidbody>();
        }

        public void interact(ActivePlayer player)
        {
            
            if(player == ActivePlayer.Human)
            {
                playerObject = GameManager.Instance.Human;
            }
            else if (both)
            {
                playerObject = GameManager.Instance.Animal;
            }

            playerObject.GetComponent<Player>().togglePush();
            pushing = !pushing;

            //rigidBody.gameObject.transform.Translate(moveDirection.x * Time.deltaTime, 0.0f, moveDirection.z * Time.deltaTime);
        }

        private void Update()
        {
            // if (gameObject.GetComponent<Rigidbody>())
            // {
            //     stopInteract();
            // }
            if (pushing)
            {
                pushforce = playerObject.GetComponent<Player>().moveDirection;
            }
            else
            {
                pushforce = new Vector3(0,-2,0);
            }
            rigidBody.gameObject.transform.Translate(pushforce.x * Time.deltaTime, 0.0f, pushforce.z * Time.deltaTime);
        }

    }
}