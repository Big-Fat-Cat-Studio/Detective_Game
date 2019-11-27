using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class CombineItem : MonoBehaviour
    {
        //Variables
        public GameObject combineManager;
        public string combineItemID;
        public string key;

        //Unity functions
        private void Update()
        {
            if(Input.GetKeyDown(this.key))
            {
                combineManager.GetComponent<CombineManager>().InsertItem(this.combineItemID);
                Destroy(this.gameObject);
            }
        }
    }
}