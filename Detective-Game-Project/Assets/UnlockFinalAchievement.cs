using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using Steamworks;

namespace Scripts
{
    public class UnlockFinalAchievement : MonoBehaviour
    {
        //Variables
        public VideoPlayer creditsVideo;

        private bool thirdAchievementStatus;

        //Unity functions
        private void Start()
        {
            if (AchievementsManager.Instance != null)
            {
                SteamUserStats.GetAchievement("level_4", out thirdAchievementStatus);
                if (thirdAchievementStatus)
                {
                    SteamUserStats.SetAchievement("the_reunion");
                    SteamUserStats.StoreStats();
                    SteamAPI.RunCallbacks();
                }
            }
            StartCoroutine(BackToMenu());
        }

        //Coroutines
        private IEnumerator BackToMenu()
        {
            WaitForSeconds timer = new WaitForSeconds(1.0f);
            for(; ; )
            {
                yield return timer;
                if(!creditsVideo.isPlaying)
                {
                    SceneManager.LoadScene(0);
                }
            }
        }
    }
}