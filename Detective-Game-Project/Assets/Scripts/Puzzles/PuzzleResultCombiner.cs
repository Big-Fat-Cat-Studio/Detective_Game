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
                else
                {
                    Debug.LogError("Unexpected solution type found");
                }
            }
        }
    }
}