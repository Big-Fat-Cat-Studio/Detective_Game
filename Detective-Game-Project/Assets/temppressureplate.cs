using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class temppressureplate : MonoBehaviour
    {
        //Variables
        public GameObject[] toxicSprinklers;
        public float shutdownTimer;

        private bool isPaused = false;

        //Unity functions
        private void OnTriggerEnter(Collider other)
        {
            if ((other.gameObject.tag == "Human" || other.gameObject.tag == "Animal") && !this.isPaused)
            {
                print("getriggered");
                StartCoroutine(PauseSPrinklers());
            }
        }

        //Coroutines
        private IEnumerator PauseSPrinklers()
        {
            this.isPaused = true;
            WaitForSeconds timer = new WaitForSeconds(this.shutdownTimer);
            foreach (GameObject sprinkler in toxicSprinklers)
            {
                sprinkler.GetComponent<ToxicSprinkler>().Disable();
            }
            yield return timer;
            foreach (GameObject sprinkler in toxicSprinklers)
            {
                sprinkler.GetComponent<ToxicSprinkler>().Enable();
            }
        }
    }
}