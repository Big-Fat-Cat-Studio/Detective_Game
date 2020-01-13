using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class MainControllerManager : MonoBehaviour
    {
        public InputType inputDeviceP1;
        public InputType inputDeviceP2;

        //Singleton, so we can access human/animal everywhere
        public static MainControllerManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}