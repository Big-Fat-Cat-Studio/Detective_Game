using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class SequencePuzzleItem : MonoBehaviour
    {
        //Variables
        public GameObject sequencePuzzleManager;
        public int sequenceItemID;
        public string key;

        //Unity functions
        void Update()
        {
            if(Input.GetKeyDown(key))
            {
                sequencePuzzleManager.GetComponent<SequencePuzzleMain>().InsertInput(this.sequenceItemID);
            }
        }
    }
}