using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    [System.Serializable]
    public class SaveData
    {
        public string[] completedLevels;
        public string levelName;
        public int levelIndex;
        public int pissCounter;
        public int poopCounter;
        public bool isDummySave;
        public bool isCheckpoint;

        public SaveData(int levelIndex, int pissCounter, int poopCounter, string levelName, bool isDummySave)
        {
            this.levelName = levelName;
            this.levelIndex = levelIndex;
            this.pissCounter = pissCounter;
            this.poopCounter = poopCounter;
            //this.completedLevels = completedLevels;
            this.isDummySave = isDummySave;
            //this.isCheckpoint = isCheckpoint;
        }
    }
}