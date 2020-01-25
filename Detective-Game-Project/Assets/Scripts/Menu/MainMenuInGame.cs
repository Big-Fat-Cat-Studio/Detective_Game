using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class MainMenuInGame : MonoBehaviour
    {
        public GameObject MainMenu;
        public GameObject Options;

        public void OpenMenu()
        {
            MainMenu.SetActive(true);
            Options.SetActive(false);
        }
    }
}