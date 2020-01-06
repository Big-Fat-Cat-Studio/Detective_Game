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

        private bool test;

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
            if (Input.GetKeyDown(KeyCode.F1))
            {
                UnlockAchievement("test_achievement");
            }
            if(Input.GetKeyDown(KeyCode.F2))
            {
                LockAchievement("test_achievement");
                print(test);
            }
        }
        //Custom functions
        public void UnlockAchievement(string id)
        {
            SteamUserStats.GetAchievement(id, out test);
            if(!test)
            {
                SteamUserStats.SetAchievement(id);
                SteamUserStats.StoreStats();
                SteamAPI.RunCallbacks();
            }
        }
        public void LockAchievement(string id)
        {
            SteamUserStats.GetAchievement(id, out test);
            if (test)
            {
                SteamUserStats.ClearAchievement(id);
                SteamUserStats.StoreStats();
            }
        }
    }
}