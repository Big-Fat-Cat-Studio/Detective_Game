using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Button : MonoBehaviour
    {
        //Variables
        public GameObject target;

        //Unity functions
        private void OnTriggerEnter(Collider collision)
        {
            if (ReferenceEquals(GameManager.Instance.Human, collision.gameObject))
            {
                target.GetComponent<IButtonTarget>().Activate();
            }
        }
    }
}