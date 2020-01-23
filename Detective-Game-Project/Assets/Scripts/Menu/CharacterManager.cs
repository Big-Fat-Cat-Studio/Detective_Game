using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class CharacterManager : MonoBehaviour
    {
        //DontDestroyOnLoad
        public static CharacterManager Instance { get; set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        //Variables
        public ActivePlayer PlayerOne = ActivePlayer.Human;
        public ActivePlayer PlayerTwo = ActivePlayer.Animal;
    }
}