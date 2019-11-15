using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    public class Clue : MonoBehaviour
    {
        public GameObject cluePanel;
        public string clueName;
        public string description;

        public GameObject getClueBoardClue()
        {
            GameObject clueBoardClue = Instantiate(cluePanel);
            clueBoardClue.GetComponentInChildren<Text>().text = clueName + " - " + description;
            return clueBoardClue;
        }
    }
}
