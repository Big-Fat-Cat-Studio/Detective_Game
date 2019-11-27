using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    public class SequencePuzzleMain : MonoBehaviour
    {
        //Variables
        public List<GameObject> solution;
        public Light lamp;
        public float maxCountdown;

        private List<Color> colorSequence;
        private List<string> convertedSolution;
        private List<string> input;
        private Text timerText;
        private int currentColor = 0;
        private float timer = 0;
        private bool sequenceStillCorrect = true;
        private bool puzzleHasStarted = false;

        //Unity functions
        private void Start()
        {
            this.timer = this.maxCountdown;
            this.timerText = GameObject.FindGameObjectWithTag("Timer").GetComponent<Text>();
            this.colorSequence = new List<Color>();
            this.input = new List<string>();
            this.convertedSolution = this.ConvertSolution();
            this.colorSequence.Add(Color.white);
            this.InsertColors();
            StartCoroutine(this.CheckSolution());
            StartCoroutine(this.ShowSequence());
            
        }
        private void Update()
        {
            if(puzzleHasStarted)
            {
                this.timer -= Time.deltaTime;
                this.timerText.text = "Timer: " + (this.timer * -1).ToString();
            }
        }

        //Custom functions
        public void InsertInput(string sequenceItemColor)
        {
            if (this.input.Count < this.convertedSolution.Count)
            {
                this.input.Add(sequenceItemColor);
                this.puzzleHasStarted = true;
            }
        }
        public void InsertColors()
        {
            for(int i = 0; i < this.solution.Count; i++)
            {
                this.colorSequence.Add(this.solution[i].gameObject.GetComponent<SequencePuzzlePressurePlate>().plateColor);
            }
        }
        private List<string> ConvertSolution()
        {
            List<string> result = new List<string>();
            foreach(GameObject sequenceItem in solution)
            {
                result.Add(sequenceItem.GetComponent<SequencePuzzlePressurePlate>().sequenceItemColorID);
            }
            return result;
        }
        private SequencePuzzleStatus Compare()
        {
            if (this.input.Count < this.convertedSolution.Count)
            {
                if(this.maxCountdown == 0)
                {
                    return SequencePuzzleStatus.Incomplete;
                }
                else
                {
                    if(this.timer <= 0)
                    {
                        print("te laat");
                        return SequencePuzzleStatus.Wrong;
                    }
                    else
                    {
                        return SequencePuzzleStatus.Incomplete;
                    }
                }
                
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
            this.timer = this.maxCountdown;
            this.puzzleHasStarted = false;
            this.timerText.text = "";
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
        private IEnumerator ShowSequence()
        {
            for(; ; )
            {
                WaitForSeconds switchTimer = new WaitForSeconds(1.0f);
                WaitForSeconds pauseTimer = new WaitForSeconds(2.0f);
                this.currentColor += 1;
                if (this.currentColor >= this.colorSequence.Count)
                {
                    this.currentColor = 0;
                }
                this.lamp.color = this.colorSequence[currentColor];
                if (this.currentColor == 0)
                {
                    yield return pauseTimer;
                }
                else
                {
                    yield return switchTimer;
                }
            }
        }
    }
}