using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class TutorialPanelPickup : TutorialPanel
    {
        public override void showText(ActivePlayer player)
        {
            if (player == ActivePlayer.Human)
            {
                showTextByControlType(GameManager.Instance.Human.GetComponent<Player>().inputType);
            }
            else
            {
                showTextByControlType(GameManager.Instance.Animal.GetComponent<Player>().inputType);
            }
        }

        private void showTextByControlType(InputType type)
        {
            //This is kinda redundant right now since they're both X but maybe later it'll be more useful
            string buttonToPress;

            if (type == InputType.Controller)
            {
                buttonToPress = "X";
            }
            else
            {
                buttonToPress = "X";
            }

            content.text = string.Format(originalText, buttonToPress).Replace("\\n", "\n");
        }
    }
}
