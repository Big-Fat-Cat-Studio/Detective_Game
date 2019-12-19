using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class ToxicSprinkler : MonoBehaviour
    {
        //Variables
        public ParticleSystem water;

        //Unity functions
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Human" || other.gameObject.tag == "Animal")
            {
                other.gameObject.GetComponent<RespawnPlayer>().Respawn();
            }
        }

        //Custom functions
        public void Disable()
        {
            this.gameObject.GetComponent<BoxCollider>().isTrigger = true;
            water.Stop();
        }
        
    }
}