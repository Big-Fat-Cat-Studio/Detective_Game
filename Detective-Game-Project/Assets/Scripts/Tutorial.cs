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

        public override void interact()
        {
            if (Tutorialpanel.activeSelf)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        public void Resume()
        {
            Tutorialpanel.SetActive(false);
            Time.timeScale = 1;
        }

        public void Pause()
        {
            Tutorialpanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
