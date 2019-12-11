using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class CharacterSelect : MonoBehaviour
    {
        private ActivePlayer player1 = ActivePlayer.Human;
        private ActivePlayer player2 = ActivePlayer.Animal;

        public void Swap()
        {
            if(player1 == ActivePlayer.Human)
            {
                this.player1 = ActivePlayer.Animal;
                this.player2 = ActivePlayer.Human;
            }
            else
            {
                this.player1 = ActivePlayer.Human;
                this.player2 = ActivePlayer.Animal;
            }
        }
        public void StartGame()
        {
            GameManager.Instance.PlayerOne = this.player1;
            GameManager.Instance.PlayerTwo = this.player2;
        }
    }
}