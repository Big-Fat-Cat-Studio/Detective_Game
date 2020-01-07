using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class TempSolution : MonoBehaviour
    {
        public void ActivateSolution()
        {
            Destroy(this.gameObject);
        }
    }
}