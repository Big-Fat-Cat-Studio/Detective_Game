using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class temppressureplate : MonoBehaviour, IActivateWithPiss
    {
        //Variables
        public GameObject[] toxicSprinklers;
        public float shutdownTimer;

        private bool isDisabled = false;
        private bool isPaused = false;
        private List<GameObject> colliders;

        private void Start()
        {
            colliders = new List<GameObject>();
        }

        //Unity functions
        private void OnTriggerEnter(Collider other)
        {
            if (ReferenceEquals(other.gameObject, GameManager.Instance.Human) || ReferenceEquals(other.gameObject, GameManager.Instance.Animal))
            {
                if (!this.isPaused)
                {
                    StartCoroutine(PauseSPrinklers());
                }

                if (colliders.Count == 0)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);
                }

                colliders.Add(other.gameObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (ReferenceEquals(other.gameObject, GameManager.Instance.Human) || ReferenceEquals(other.gameObject, GameManager.Instance.Animal))
            {
                colliders.Remove(other.gameObject);
                if (colliders.Count == 0)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
                }
            }
        }

        //Custom functions
        public void Activation()
        {
            this.TurnSprinklersOff();
        }
        private void TurnSprinklersOff()
        {
            this.isDisabled = true;
            if(!this.isPaused)
            {
                foreach (GameObject sprinkler in toxicSprinklers)
                {
                    sprinkler.GetComponent<ToxicSprinkler>().Disable();
                }
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
            if(!this.isDisabled)
            {
                foreach (GameObject sprinkler in toxicSprinklers)
                {
                    sprinkler.GetComponent<ToxicSprinkler>().Enable();
                }
                this.isPaused = false;
            }
        }
    }
}