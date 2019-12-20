using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Tutorial : InteractableObject
    {
        public GameObject Tutorialpanel;

        void Start()
        {
            Tutorialpanel.SetActive(false);
        }

        public override void interact(ActivePlayer player)
        {
            if (Tutorialpanel.activeSelf)
            {
                Resume();
            }
            else
            {
                Pause(player);
            }
        }

        public void Resume()
        {
            Tutorialpanel.SetActive(false);
            Time.timeScale = 1;
        }

        public void Pause(ActivePlayer player)
        {
            Tutorialpanel.SetActive(true);
            TutorialPanel panel = Tutorialpanel.GetComponent<TutorialPanel>();
            if (panel != null)
            {
                panel.showText(player);
            }
            Time.timeScale = 0;
        }
    }
}
