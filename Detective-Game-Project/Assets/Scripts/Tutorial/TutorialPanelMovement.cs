using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class TutorialPanelMovement : TutorialPanel
    {
        public override void showText(ActivePlayer player)
        {
            if (player == ActivePlayer.Human)
            {
                showTextByControlType(GameManager.Instance.Human.GetComponent<Player>().inputType, player);
            }
            else
            {
                showTextByControlType(GameManager.Instance.Animal.GetComponent<Player>().inputType, player);
            }
        }

        private void showTextByControlType(InputType type, ActivePlayer player)
        {
            if (type == InputType.Controller)
            {
                content.text = string.Format(originalText, "left joystick", GameManager.Instance.getPlayerName(player), "A", "right joystick").Replace("\\n", "\n");
            }
            else
            {  
                content.text = string.Format(originalText, "WASD keys", GameManager.Instance.getPlayerName(player), "space", "mouse").Replace("\\n", "\n");
            }
        }
    }
}
