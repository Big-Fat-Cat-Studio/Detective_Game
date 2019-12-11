using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class SequencePuzzlePressurePlate : MonoBehaviour
    {
        //Variables
        public Color plateColor;
        public GameObject sequencePuzzleManager;
        public string sequenceItemColorID;
        public float timePressed = 1f;
        private bool pressed;
        private IEnumerator currentCouroutine;

        //Unity functions
        private void OnTriggerEnter(Collider other)
        {
            if (ReferenceEquals(other.gameObject, GameManager.Instance.Human) || ReferenceEquals(other.gameObject, GameManager.Instance.Animal))
            {
                if (!pressed)
                {
                    sequencePuzzleManager.GetComponent<SequencePuzzleMain>().InsertInput(this.sequenceItemColorID);
                    transform.position = new Vector3(transform.position.x, transform.position.y - 0.08f, transform.position.z);
                    pressed = true;
                }
                
                if (currentCouroutine != null)
                {
                    StopCoroutine(currentCouroutine);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (ReferenceEquals(other.gameObject, GameManager.Instance.Human) || ReferenceEquals(other.gameObject, GameManager.Instance.Animal))
            {
                currentCouroutine = pressurePlateUp();
                StartCoroutine(currentCouroutine);
            }
        }

        private IEnumerator pressurePlateUp()
        {
            yield return new WaitForSeconds(timePressed);
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.08f, transform.position.z);
            pressed = false;
            currentCouroutine = null;
        }
    }
}