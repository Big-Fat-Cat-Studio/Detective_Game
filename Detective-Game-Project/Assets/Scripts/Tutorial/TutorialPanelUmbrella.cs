using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class TutorialPanelUmbrella : TutorialPanel
    {
        public override void showText(ActivePlayer player)
        {
            InputType type = GameManager.Instance.Human.GetComponent<Player>().inputType;
            string buttonToPress;

            if (type == InputType.Controller)
            {
                buttonToPress = "Y";
            }
            else
            {
                buttonToPress = "V";
            }

            content.text = string.Format(originalText, buttonToPress).Replace("\\n", "\n");
        }
    }
}
