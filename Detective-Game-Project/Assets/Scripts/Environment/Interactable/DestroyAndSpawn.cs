using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Scripts
{
    public class DestroyAndSpawn : InteractableObjectItemNeeded
    {
        public GameObject itemToSpawn;

        // TODO(HAMZA): Change to DONTDESTROYBUTSPAWN
        public bool DEBUG;
        public bool Consumed;

        // Start is called before the first frame update
        void Start()
        {
            if (DEBUG)
                interactableType = InteractableType.DEBUG;
        }

        protected override void interactSucces(ActivePlayer player, GameObject playerItem)
        {
            if (!DEBUG)
            {
                this.gameObject.SetActive(false);
                Destroy(this.gameObject);
                Instantiate(itemToSpawn, this.transform.position, this.transform.rotation);
            }
            else
            {
                if (!Consumed)
                {
                    Instantiate(itemToSpawn, (this.transform.position + new Vector3(0, .2f, -2)), this.transform.rotation);
                    Consumed = true;
                }
            }
        }
    }
}