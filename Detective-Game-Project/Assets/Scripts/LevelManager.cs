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
    }
}