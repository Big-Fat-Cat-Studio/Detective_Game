using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class CombineManager : MonoBehaviour
    {
        //Variables
        public Vector3 spawnLocation;
        public GameObject combinedItemsResult;
        public int requiredItemsAmount;

        private List<string> collectedItems;
        private bool completed = false;

        //Unity functions
        void Start()
        {
            this.collectedItems = new List<string>();
        }

        //Custom functions
        public void InsertItem(string itemID)
        {
            print(itemID);
            if (!this.completed)
            {
                this.collectedItems.Add(itemID);
                if (this.collectedItems.Count == this.requiredItemsAmount)
                {
                    Instantiate(combinedItemsResult, spawnLocation, Quaternion.identity);
                    this.completed = true;
                }
            }
        }
    }
}