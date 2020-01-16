using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Tutorial : InteractableObject
    {
        public GameObject TutorialImage;
        protected bool cannotInteract;

        void Start()
        {
            TutorialImage.SetActive(false);
        }

        public override void interact(ActivePlayer player)
        {
            if (!TutorialImage.activeSelf)
            {
                Pause();
            }
        }

        public void Resume()
        {
            if (!cannotInteract)
            {
                TutorialImage.SetActive(false);
                Time.timeScale = 1;
            }
        }

        public void Pause()
        {
            if (!cannotInteract)
            {
                TutorialImage.SetActive(true);
                Time.timeScale = 0;
                GameManager.Instance.currentTutorial = this;
            }
        }
    }
}
