using Cinemachine;
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
                playerObject = GameManager.Instance.Animal;
            }
            else 
            {
                humanispushing = !humanispushing;
                playerObject = GameManager.Instance.Human;
            }

            playerObject.GetComponent<Player>().togglePush();
        }

        private void Update()
        {
            if (humanispushing && !both)
            {
                fixPlayerPosition(ActivePlayer.Human);
                pushforce = GameManager.Instance.Human.GetComponent<HumanPlayer>().moveDirection;
                rigidBody.velocity = new Vector3(pushforce.x, 0, pushforce.z);
            }
            else if (humanispushing && dogispushing)
            {
                fixPlayerPosition(ActivePlayer.Human);
                fixPlayerPosition(ActivePlayer.Animal);

                Vector3 humanMoveDirection = GameManager.Instance.Human.GetComponent<Player>().moveDirection;
                Vector3 animalMoveDirection = GameManager.Instance.Animal.GetComponent<Player>().moveDirection;

                //check if they are on the same side of the box, first check if they are on the x-side of the box or the z-side of the box,
                //then proceed to check the proper side.
                if (Mathf.Round(humanMoveDirection.z) == 0 &&
                    ((GameManager.Instance.Human.transform.position.x - transform.position.x >= 0 &&
                    GameManager.Instance.Animal.transform.position.x - transform.position.x >= 0) ||
                    (GameManager.Instance.Human.transform.position.x - transform.position.x < 0 &&
                    GameManager.Instance.Animal.transform.position.x - transform.position.x < 0)))
                {
                    if ((humanMoveDirection.x > 0 && animalMoveDirection.x > 0) ||
                        (humanMoveDirection.x < 0 && animalMoveDirection.x < 0))
                    {
                        pushforce = GameManager.Instance.Human.GetComponent<Player>().moveDirection;
                        rigidBody.velocity = new Vector3(pushforce.x, 0, pushforce.z);
                    }
                }
                else if (Mathf.Round(humanMoveDirection.x) == 0 &&
                    ((GameManager.Instance.Human.transform.position.z - transform.position.z > 0 &&
                    GameManager.Instance.Animal.transform.position.z - transform.position.z > 0) ||
                    (GameManager.Instance.Human.transform.position.z - transform.position.z < 0 &&
                    GameManager.Instance.Animal.transform.position.z - transform.position.z < 0)))
                {
                    if ((humanMoveDirection.z > 0 && animalMoveDirection.z > 0) ||
                        (humanMoveDirection.z < 0 && animalMoveDirection.z < 0))
                    {
                        pushforce = GameManager.Instance.Human.GetComponent<Player>().moveDirection;
                        rigidBody.velocity = new Vector3(pushforce.x, 0, pushforce.z);
                    }                
                }
            }
        }

        private void fixPlayerPosition(ActivePlayer player)
        {
            if (player == ActivePlayer.Human)
            {
                GameManager.Instance.Human.transform.rotation =
                    Quaternion.Euler(new Vector3(0, Mathf.Round(GameManager.Instance.Human.transform.eulerAngles.y / 90.0f) * 90, 0));
            }
            else
            {
                GameManager.Instance.Animal.transform.rotation =
                    Quaternion.Euler(new Vector3(0, Mathf.Round(GameManager.Instance.Animal.transform.eulerAngles.y / 90.0f) * 90, 0));
            }

            if ((player == ActivePlayer.Human && ActivePlayer.Human == GameManager.Instance.PlayerOne) ||
                (player == ActivePlayer.Animal && ActivePlayer.Animal == GameManager.Instance.PlayerOne))
            {
                GameManager.Instance.CameraFollow.GetComponent<CinemachineFreeLook>().m_XAxis.Value =
                    Mathf.Round(GameManager.Instance.CameraFollow.GetComponent<CinemachineFreeLook>().m_XAxis.Value / 90.0f) * 90;
            }
            else
            {
                GameManager.Instance.CameraFollowP2.GetComponent<CinemachineFreeLook>().m_XAxis.Value =
                    Mathf.Round(GameManager.Instance.CameraFollowP2.GetComponent<CinemachineFreeLook>().m_XAxis.Value / 90.0f) * 90;
            }
        }
    }
}