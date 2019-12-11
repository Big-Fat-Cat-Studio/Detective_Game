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
        bool dogispushing = false;
        public bool both;
        int count = 0;
        bool humanispushing = false;

        private void Start()
        {
            interactableType = InteractableType.HoldButton;
            rigidBody = GetComponent<Rigidbody>();
        }

        public void interact(ActivePlayer player)
        {
            if (player == ActivePlayer.Animal)
            {
                dogispushing = !dogispushing;
            }
            if (player == ActivePlayer.Human)
            {
                humanispushing = !humanispushing;
            }
            if(player == ActivePlayer.Human)
            {
                playerObject = GameManager.Instance.Human;
            }
            else
            {
                playerObject = GameManager.Instance.Animal;
            }

            playerObject.GetComponent<Player>().togglePush();

            //rigidBody.gameObject.transform.Translate(moveDirection.x * Time.deltaTime, 0.0f, moveDirection.z * Time.deltaTime);
            Debug.Log(dogispushing);
            Debug.Log(humanispushing);
            Debug.Log(pushing);
        }

        private void Update()
        {
            // if (gameObject.GetComponent<Rigidbody>())
            // {
            //     stopInteract();
            // }
            if (both && dogispushing && humanispushing)
            {
                pushing = true;
            }
            else if (!both)
            {
              pushing = !pushing;  
            }
            else
            {
                pushing = false;
            }
            if (pushing && humanispushing && !both)
            {
                pushforce = playerObject.GetComponent<Player>().moveDirection;
            }
            else if (pushing && humanispushing && dogispushing)
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