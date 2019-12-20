using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Scripts
{
    public abstract class TutorialPanel : MonoBehaviour
    {
        public Text content;
        public string originalText;

        public abstract void showText(ActivePlayer player);
    }
}