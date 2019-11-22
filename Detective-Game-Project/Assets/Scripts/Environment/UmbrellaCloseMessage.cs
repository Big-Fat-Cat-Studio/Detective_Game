using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts {
    public class UmbrellaCloseMessage : MonoBehaviour
    {
        public string message;

        private void OnTriggerEnter(Collider other)
        {
            if (ReferenceEquals(other.gameObject, GameManager.Instance.Human))
            {
                GameManager.Instance.showAfterInteractText(ActivePlayer.Human, message);
            }
        }

        private void Start()
        {
            if (!GameManager.Instance.Human.GetComponent<HumanPlayer>().umbrellaActiveOnStart)
            {
                Destroy(this.gameObject);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.Instance.getButtonPressForPlayer(ActivePlayer.Human, "Special2", ButtonPress.Down))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
