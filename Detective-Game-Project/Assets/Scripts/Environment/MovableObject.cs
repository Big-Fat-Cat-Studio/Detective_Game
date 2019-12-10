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
            Debug.Log(count);
            if (count == 1)
            {
                dogispushing = true;
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

            if (!both)
            {
              pushing = !pushing;  
            }
            
            if (both && playerObject == GameManager.Instance.Animal && !dogispushing)
            {
                playerObject.transform.parent = gameObject.transform;
            }
            else if(both && playerObject == GameManager.Instance.Animal)
            {
                count = 0;
                playerObject.transform.parent = null;
            }

            if (both && playerObject == GameManager.Instance.Animal)
            {   
                foreach (Transform eachChild in transform) {
                    if (eachChild.gameObject.tag == "Animal")
                    {
                        count = 1;
                    }
                }
            }
            if (count > 0)
            {
                dogispushing = true;
            }
            else
            {
                dogispushing = false;
            }
            if (playerObject == GameManager.Instance.Human)
            {
                humanispushing = true;
            }
            else
            {
                humanispushing = false;
            }
            if (both && dogispushing && humanispushing)
            {
                pushing = !pushing;
            }
            //rigidBody.gameObject.transform.Translate(moveDirection.x * Time.deltaTime, 0.0f, moveDirection.z * Time.deltaTime);
        }

        private void Update()
        {
            // if (gameObject.GetComponent<Rigidbody>())
            // {
            //     stopInteract();
            // }
            if (pushing && playerObject == GameManager.Instance.Human)
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