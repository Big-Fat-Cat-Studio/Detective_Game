using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class LevelManager : MonoBehaviour
    {
        //Variables
        private SaveData savedData;

    //Unity functions
    private void Start()
        {
            this.savedData = SaveSystem.LoadProgress();
            this.CompletePuzzles();
        }

        //Custom functions
        private void CompletePuzzles()
        {
            foreach(string puzzle in savedData.completedPuzzles)
            {
                IPuzzleManager currentPuzzle = this.transform.Find(puzzle).gameObject.GetComponent<IPuzzleManager>();
                currentPuzzle.CompletePuzzle();
            }
        }
        private void SetPlayerLocations()
        {
            //set human position
            GameManager.Instance.Human.GetComponent<CharacterController>().enabled = false;
            GameManager.Instance.Human.transform.position = savedData.playerHPos;
            GameManager.Instance.Human.GetComponent<CharacterController>().enabled = true;
            //set dog position
            GameManager.Instance.Animal.GetComponent<CharacterController>().enabled = false;
            GameManager.Instance.Animal.transform.position = savedData.playerDPos;
            GameManager.Instance.Animal.GetComponent<CharacterController>().enabled = true;
        }
    }
}