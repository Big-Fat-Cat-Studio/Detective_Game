using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class PissDetector : MonoBehaviour
    {
        //Variables
        public GameObject objectToActivate;
        public ParticleSystem breakParticles;

        private bool hasTriggered = false;

        //Unity fucntions
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Piss" && !hasTriggered)
            {
                breakParticles.Play();
                hasTriggered = true;
                objectToActivate.GetComponent<IActivateWithPiss>().Activation();
                gameObject.GetComponent<AudioSource>().Play();
            }
        }
    }
}