using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class RespawnPlayer : MonoBehaviour
    {
        //Variables
        public int yDeathLevel;

        private Vector3 spawnLocation;

        //Unity functions
        private void Start()
        {
            this.spawnLocation = this.gameObject.transform.position;
        }
        private void FixedUpdate()
        {
            if(this.gameObject.transform.position.y < this.yDeathLevel)
            {
                this.gameObject.GetComponent<CharacterController>().enabled = false;
                this.gameObject.transform.position = this.spawnLocation;
                this.gameObject.GetComponent<CharacterController>().enabled = true;
            }
        }
    }
}