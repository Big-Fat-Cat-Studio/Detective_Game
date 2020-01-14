using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class DogAchievementTrigger : MonoBehaviour
    {
        //Variables
        public string achievementName;
        //Unity functions
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Animal")
            {
                AchievementsManager.Instance.UnlockAchievement(achievementName);
            }
        }
    }
}