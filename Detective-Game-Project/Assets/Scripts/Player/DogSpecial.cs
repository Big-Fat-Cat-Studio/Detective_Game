using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class DogSpecial : MonoBehaviour
    {
        float lifeTime = 15f;
        bool triggered = false;

        // Start is called before the first frame update
        void Start()
        {
            Destroy(gameObject, lifeTime);
        }

        void OnTriggerEnter(Collider collision)
        {
            if (triggered) return;

            if (collision.tag == "Human")
            {
                triggered = true;
                StartCoroutine(ShitSlow(collision));
                this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }

        //void OnTriggerExit(Collider collision)
        //{
        //    if (!triggered) return;

        //    if (collision.tag == "Human")
        //    {
        //        triggered = false;
        //        collision.gameObject.GetComponent<HumanPlayer>().handleSlow(_jumpHeight: 6f, _movementSpeed: 4f);
        //    }
        //}

        void OnDestroy()
        {
            if (!triggered) return;
            GameManager.Instance.Human.GetComponent<HumanPlayer>().handleSlow(_jumpHeight: 6f, _movementSpeed: 4f);
        }

        private IEnumerator ShitSlow(Collider collision)
        {
            print("slowing");
            collision.gameObject.GetComponent<HumanPlayer>().handleSlow(_jumpHeight: 4f, _movementSpeed: 2f);
            yield return new WaitForSeconds(5.0f);
            collision.gameObject.GetComponent<HumanPlayer>().handleSlow(_jumpHeight: 6f, _movementSpeed: 4f);
            print("speeding");
        }
    }
}
