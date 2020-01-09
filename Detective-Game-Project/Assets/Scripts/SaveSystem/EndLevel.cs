using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

namespace Scripts
{
    public class EndLevel : InteractableObject
    {
        //Variables
        public VideoPlayer endCutscene;
        public string nextLevelName;
        public string achievementName;
        private bool cutsceneHasStarted = false;

        //Unity functions
        void Start()
        {
            interactableType = InteractableType.EndLevel;
        }
        private void Update()
        {
            if(this.cutsceneHasStarted)
            {
                if(!endCutscene.isPlaying)
                {
                    this.cutsceneHasStarted = false;
                    this.LoadNextLevel();
                }
            }
        }

        //Custom functions
        public override void interact(ActivePlayer player)
        {
            //SaveData new_save = new SaveData(recalculateCompletedLevels(GameManager.Instance.saveData.completedLevels), this.nextLevelName, false);
            //SaveSystem.SaveProgress(new_save);
            //AchievementsManager.Instance.UnlockAchievement(achievementName);
            GameManager.Instance.PlayerCamera.SetActive(false);
            GameManager.Instance.PlayerCameraP2.SetActive(false);
            GameManager.Instance.InteractTextPlayerOne.SetActive(false);
            GameManager.Instance.InteractText.SetActive(false);
            GameManager.Instance.AfterInteractTextPlayerOne.SetActive(false);
            GameManager.Instance.AfterInteractText.SetActive(false);
            GameManager.Instance.Human.SetActive(false);
            GameManager.Instance.Animal.SetActive(false);
            GameManager.Instance.CutsceneCamera.SetActive(true);
            this.endCutscene.Play();
            StartCoroutine(StartupTimer());
        }
        private void LoadNextLevel()
        {
            SceneManager.LoadScene(this.nextLevelName);
        }
        private string[] recalculateCompletedLevels(string[] completedLevelsOld)
        {
            string[] result = new string[completedLevelsOld.Length + 1];
            for(int current = 0; current < completedLevelsOld.Length; current++)
            {
                result[current] = completedLevelsOld[current];
            }
            result[result.Length - 1] = SceneManager.GetActiveScene().name;
            return result;
        }

        //Coroutines
        private IEnumerator StartupTimer()
        {
            yield return new WaitForSeconds(2.0f);
            this.cutsceneHasStarted = true;
        }
    }
}
