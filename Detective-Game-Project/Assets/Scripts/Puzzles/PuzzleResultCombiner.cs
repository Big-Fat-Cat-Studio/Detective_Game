using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class PuzzleResultCombiner : MonoBehaviour, IPuzzleResult
    {
        //Variables
        public SolutionType solutionType;
        public int requiredResultamount;
        public ParticleSystem[] sprinklers;
        public GameObject srinklersound;
        private int currentResultAmount = 0;

        //Custom functions
        public void ActivateSolution()
        {
            this.currentResultAmount += 1;
            if(this.currentResultAmount == requiredResultamount)
            {
                if(this.solutionType == SolutionType.Destroy)
                {
                    Destroy(this.gameObject);
                }
                else if(this.solutionType == SolutionType.Sprinkler)
                {
                    foreach (ParticleSystem sprinkler in this.sprinklers)
                    {
                        sprinkler.Play();
                    }
                    srinklersound.GetComponent<AudioSource>().Play();
                    Destroy(this.gameObject);
                }
                else
                {
                    Debug.LogError("Unexpected solution type found");
                }
            }
        }
    }
}