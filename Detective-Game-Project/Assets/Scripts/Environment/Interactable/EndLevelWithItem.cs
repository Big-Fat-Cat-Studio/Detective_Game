using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

namespace Scripts
{
    public class EndLevelWithItem : InteractableObjectItemNeeded, ISkipable
    {
        //Variables
        public VideoPlayer endCutscene;
        public string achievementName;
        public string nextLevelName;
        private bool cutsceneHasStarted = false;

        //Unity functions
        void Start()
        {
            interactableType = InteractableType.ItemNeeded;
        }
        private void Update()
        {
            if (this.cutsceneHasStarted)
            {
                if (!endCutscene.isPlaying)
                {
                    SetLevel();
                    this.cutsceneHasStarted = false;
                    this.LoadNextLevel();
                }
            }
        }


        void SetLevel()
        {
            int CurrentLevel = SceneManager.GetActiveScene().buildIndex;
            int Unlocked = PlayerPrefs.GetInt("Level");
            if (Unlocked <= CurrentLevel)
            {
                PlayerPrefs.SetInt("Level", CurrentLevel + 1);
            }
        }


        protected override void interactSucces(ActivePlayer player, GameObject playerItem)
        {
            if (AchievementsManager.Instance != null)
            {
                AchievementsManager.Instance.UnlockAchievement(achievementName);
            }
            GameManager.Instance.PlayerCamera.SetActive(false);
            GameManager.Instance.PlayerCameraP2.SetActive(false);
            GameManager.Instance.InteractTextP1.SetActive(false);
            GameManager.Instance.InteractTextP2.SetActive(false);
            GameManager.Instance.AfterInteractTextP1.SetActive(false);
            GameManager.Instance.AfterInteractTextP2.SetActive(false);
            GameManager.Instance.Human.SetActive(false);
            GameManager.Instance.Animal.SetActive(false);
            GameManager.Instance.CutsceneCamera.SetActive(true);
            this.endCutscene.Play();
            StartCoroutine(StartupTimer());
        }
        public void Skip()
        {
            if (endCutscene.isPlaying)
            {
                endCutscene.Stop();
                SetLevel();
                this.cutsceneHasStarted = false;
                this.LoadNextLevel();
            }
        }
        private void LoadNextLevel()
        {
            SceneManager.LoadScene(this.nextLevelName);
        }
        private string[] recalculateCompletedLevels(string[] completedLevelsOld)
        {
            string[] result = new string[completedLevelsOld.Length + 1];
            for (int current = 0; current < completedLevelsOld.Length; current++)
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
