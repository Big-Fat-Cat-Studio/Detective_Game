﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class DigKeyItem : Key
    {
        public string pickUpItemText;
        Animator animator;

        // Start is called before the first frame update
        void Start()
        {
            interactableType = InteractableType.Normal;
            interactable = true;
        }

        protected override void Update()
        {
            if (interactableType == InteractableType.Pickup)
            {
                base.Update();
            }
        }

        public override void interact(ActivePlayer player)
        {
            if (interactableType == InteractableType.Pickup)
            {
                pickUpItem();
            }
            else
            {
                interactable = false;
                GameManager.Instance.Animal.GetComponentInChildren<Animator>().SetTrigger("dig");
                GameManager.Instance.Animal.GetComponent<AnimalPlayer>().cannotmove = true;
                StartCoroutine(digAnimation());
            }
        }

        IEnumerator digAnimation()
        {
            yield return new WaitForSeconds(3f);
            GameManager.Instance.Animal.GetComponent<AnimalPlayer>().cannotmove = false;
            interactableType = InteractableType.Pickup;
            PlayerThatCanInteract = ActivePlayer.Both;
            interactMessage = pickUpItemText;
            GameManager.Instance.Animal.GetComponentInChildren<PlayerInteract>().giveItem(this.gameObject);
        }
    }
}