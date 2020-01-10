using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scripts
{
    public class CharacterSelect : MonoBehaviour
    {
        public Image humanBorder;
        public Image dogBorder;
        public Text humanText;
        public Text dogText;

        private ActivePlayer player1 = ActivePlayer.Human;
        private ActivePlayer player2 = ActivePlayer.Animal;
        private Color player1Color = new Color(1, 0, 0, 1);
        private Color player2Color = new Color(0, 0, 1, 1);

        public void Swap()
        {
            if(player1 == ActivePlayer.Human)
            {
                this.player1 = ActivePlayer.Animal;
                this.player2 = ActivePlayer.Human;
                this.humanBorder.color = player2Color;
                this.humanText.text = "Player 2";
                this.dogBorder.color = player1Color;
                this.dogText.text = "Player 1";
            }
            else
            {
                this.player1 = ActivePlayer.Human;
                this.player2 = ActivePlayer.Animal;
                this.humanBorder.color = player1Color;
                this.humanText.text = "Player 1";
                this.dogBorder.color = player2Color;
                this.dogText.text = "Player 2";
            }
        }
        public void StartGame()
        {
            CharacterManager.Instance.PlayerOne = this.player1;
            CharacterManager.Instance.PlayerTwo = this.player2;
            //nog nodig: bepalen welk level geladen moet worden; GameManager.Instance.levelToLoad ofzo?
            SceneManager.LoadScene("Warehouse");
        }
    }
}