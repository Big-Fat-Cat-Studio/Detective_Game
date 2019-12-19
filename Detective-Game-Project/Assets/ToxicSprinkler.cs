using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class ToxicSprinkler : MonoBehaviour
    {
        //Variables
        public ParticleSystem water;

        private bool shouldKill = true;

        //Unity functions
        private void OnTriggerEnter(Collider other)
        {
            if((other.gameObject.tag == "Human" || other.gameObject.tag == "Animal") && this.shouldKill)
            {
                other.gameObject.GetComponent<RespawnPlayer>().Respawn();
            }
        }

        //Custom functions
        public void Disable()
        {
            this.shouldKill = false;
            water.Stop();
        }
        
    }
}