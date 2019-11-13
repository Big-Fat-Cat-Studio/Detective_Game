using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class SequencePuzzleMain : MonoBehaviour
    {
        //Variables
        public List<GameObject> solution;

        public List<int> convertedSolution;
        public List<int> input;
        private bool sequenceStillCorrect = true;

        //Unity functions
        private void Start()
        {
            this.convertedSolution = this.ConvertSolution();
            StartCoroutine(this.CheckSolution());
        }

        //Custom functions
        public void InsertInput(int sequenceItemID)
        {
            if(this.input.Count < this.convertedSolution.Count)
            {
                this.input.Add(sequenceItemID);
            }
        }
        private List<int> ConvertSolution()
        {
            List<int> result = new List<int>();
            foreach(GameObject sequenceItem in solution)
            {
                result.Add(sequenceItem.GetComponent<SequencePuzzleItem>().sequenceItemID);
            }
            return result;
        }
        private SequencePuzzleStatus Compare()
        {
            if(this.input.Count < this.convertedSolution.Count)
            {
                return SequencePuzzleStatus.Incomplete;
            }
            else
            {
                for(int current = 0; current < convertedSolution.Count; current++)
                {
                    print(this.sequenceStillCorrect);
                    if(this.convertedSolution[current] == this.input[current] && this.sequenceStillCorrect)
                    {
                        this.sequenceStillCorrect = true;
                    }
                    else
                    {
                        this.sequenceStillCorrect = false;
                    }
                }
                if(this.sequenceStillCorrect)
                {
                    return SequencePuzzleStatus.Correct;
                }
                else
                {
                    return SequencePuzzleStatus.Wrong;
                }
            }
        }
        private void ResetSequencePuzzle()
        {
            this.input.Clear();
            this.sequenceStillCorrect = true;
        }

        //Coroutines
        private IEnumerator CheckSolution()
        {
            WaitForSeconds checkTimer = new WaitForSeconds(1.0f);
            for (; ; )
            {
                SequencePuzzleStatus status = this.Compare();
                if (status == SequencePuzzleStatus.Correct)
                {
                    print("player entered correct solution");
                }
                else if (status == SequencePuzzleStatus.Incomplete)
                {
                    print("result is incomplete");
                }
                else
                {
                    ResetSequencePuzzle();
                    print("player has entered wrong solution");
                }
                yield return checkTimer;
            }
        }
    }
}