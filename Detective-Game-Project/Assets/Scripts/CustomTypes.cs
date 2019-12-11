using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    [System.Serializable]
    public class SaveData
    {
        public Vector3 playerHPos;
        public Vector3 playerDPos;
        public string[] completedPuzzles;
        public string[] completedLevels;
        public string levelName;
        public bool isDummySave;
        public bool isCheckpoint;

        public SaveData(string[] completedLevels, string levelName, bool isDummySave)
        {
            this.levelName = levelName;
            this.completedLevels = completedLevels;
            //this.completedPuzzles = completedPuzzles;
            this.isDummySave = isDummySave;
            //this.isCheckpoint = isCheckpoint;
            //this.playerHPos = playerHPos;
            //this.playerDPos = playerDPos;
        }
    }
}