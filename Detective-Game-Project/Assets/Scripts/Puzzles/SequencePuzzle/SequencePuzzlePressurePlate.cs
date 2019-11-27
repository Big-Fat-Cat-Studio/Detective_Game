using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class SequencePuzzlePressurePlate : MonoBehaviour
    {
        //Variables
        public Color plateColor;
        public GameObject sequencePuzzleManager;
        public string sequenceItemColorID;

        //Unity functions
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Animal" || other.gameObject.tag == "Human")
            {
                print("test");
                sequencePuzzleManager.GetComponent<SequencePuzzleMain>().InsertInput(this.sequenceItemColorID);
            }
        }
    }
}