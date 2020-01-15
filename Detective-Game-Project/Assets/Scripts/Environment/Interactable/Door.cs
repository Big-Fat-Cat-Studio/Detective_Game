using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Door : InteractableObjectItemNeeded
    {
        private bool doorOpened;
        private float amountRotated;

        protected override void interactSucces(ActivePlayer player, GameObject playerItem)
        {
            doorOpened = true;
            interactable = false;
            amountRotated = 0f;
        }

        // Update is called once per frame
        void Update()
        {
            if (doorOpened && amountRotated < 90f)
            {
                this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(this.gameObject.transform.rotation.eulerAngles.x, this.gameObject.transform.rotation.eulerAngles.y + 4f, this.gameObject.transform.rotation.eulerAngles.z));
                amountRotated += 4f;
                gameObject.GetComponent<AudioSource>().Play();
            }
        }
    }
}
