using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class ToxicSprinklerAlt : MonoBehaviour
    {
        public int rotationSpeed;

        private void Update()
        {
            this.gameObject.transform.Rotate(new Vector3(0, rotationSpeed, 0), Space.World);
        }
    }
}