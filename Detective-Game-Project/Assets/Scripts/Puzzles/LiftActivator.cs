using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class LiftActivator : MonoBehaviour, IPuzzleResult
    {
        public void ActivateSolution()
        {
            GetComponent<ObjectToLift>().moveAutomatically = true;
            GetComponent<ObjectToLift>().startMoving();
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
