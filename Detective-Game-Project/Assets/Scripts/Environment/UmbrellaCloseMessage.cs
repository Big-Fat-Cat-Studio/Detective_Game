using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts {
    public class UmbrellaCloseMessage : MonoBehaviour
    {
        public string message;
        private HumanPlayer human;

        private void OnTriggerEnter(Collider other)
        {
            if (ReferenceEquals(other.gameObject, human.gameObject))
            {
                if (human.umbrellaActiveOnStart)
                {
                    GameManager.Instance.showAfterInteractText(ActivePlayer.Human, message);
                }
                else
                {
                    Destroy(this.gameObject);
                }
            }
        }

        private void Start()
        {
            human = GameManager.Instance.Human.GetComponent<HumanPlayer>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!human.umbrellaActiveOnStart)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
