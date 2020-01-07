using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Checkpoint : MonoBehaviour
    {
        public int index;
        public bool detectHuman;

        private bool triggered;
        private string detectLayer;

        void Start()
        {
            detectLayer = (detectHuman ? "Human" : "Animal");
        }
        
        // Start is called before the first frame update
        private void OnTriggerEnter(Collider other)
        {
            if (triggered || !(detectLayer.Contains(LayerMask.LayerToName(other.gameObject.layer)))) return;
            if (other.gameObject.GetComponent<RespawnPlayer>().checkPointIndex > index) return;

            other.gameObject.GetComponent<RespawnPlayer>().spawnLocation = transform.position;
            triggered = true;
        }
    }
}
