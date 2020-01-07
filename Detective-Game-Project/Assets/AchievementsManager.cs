using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

namespace Scripts
{
    public class AchievementsManager : MonoBehaviour
    {
        //Variables
        public static AchievementsManager Instance { get; private set; }

        public bool testMode = false;
        public int pissCounter = 0;
        public int poopCounter = 0;

        private bool status;

        //Unity functions
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
            }
        }
        private void Update()
        {
            if(testMode)
            {
                if (Input.GetKeyDown(KeyCode.F1))
                {
                    UnlockAchievement("test_achievement");
                }
                if (Input.GetKeyDown(KeyCode.F2))
                {
                    LockAchievement("test_achievement");
                    print(status);
                }
            }
        }
        //Custom functions
        public void UnlockAchievement(string id)
        {
            SteamUserStats.GetAchievement(id, out status);
            if(!status)
            {
                SteamUserStats.SetAchievement(id);
                SteamUserStats.StoreStats();
                SteamAPI.RunCallbacks();
            }
        }
        public void LockAchievement(string id)
        {
            SteamUserStats.GetAchievement(id, out status);
            if (status)
            {
                SteamUserStats.ClearAchievement(id);
                SteamUserStats.StoreStats();
            }
        }
        //Coroutines
        private IEnumerator PissAchievementChecker()
        {
            WaitForSeconds timer = new WaitForSeconds(2.0f);
            for(; ; )
            {
                if(this.pissCounter >= 5 && this.poopCounter >= 5)
                {
                    this.UnlockAchievement("the_childish_achievement");
                    break;
                }
                yield return timer;
            }
        }
    }
}