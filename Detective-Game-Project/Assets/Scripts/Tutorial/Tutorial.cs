using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Tutorial : InteractableObject
    {
        public GameObject TutorialImage;

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
            TutorialImage.SetActive(false);
            Time.timeScale = 1;
        }

        public void Pause()
        {
            TutorialImage.SetActive(true);
            Time.timeScale = 0;
            GameManager.Instance.currentTutorial = this;
        }
    }
}
