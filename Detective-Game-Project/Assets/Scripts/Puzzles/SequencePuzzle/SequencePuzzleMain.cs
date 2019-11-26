using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class SequencePuzzleMain : MonoBehaviour
    {
        //Variables
        public List<GameObject> solution;
        public float maxCountdown;

        private List<int> convertedSolution;
        private List<int> input;
        private float timer = 0;
        private bool sequenceStillCorrect = true; 

        //Unity functions
        private void Start()
        {
            this.input = new List<int>();
            this.convertedSolution = this.ConvertSolution();
            StartCoroutine(this.CheckSolution());
        }
        private void Update()
        {
            if(true)//check of de puzzle gestart is
            {
                this.timer += Time.deltaTime;
            }
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
            if (this.input.Count < this.convertedSolution.Count && this.maxCountdown <= 0)
            {
                return SequencePuzzleStatus.Incomplete;
            }
            else if(this.input.Count < this.convertedSolution.Count && this.maxCountdown > 0 && this.timer >= this.maxCountdown)
            {
                return SequencePuzzleStatus.Wrong;
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
            this.timer = 0;
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