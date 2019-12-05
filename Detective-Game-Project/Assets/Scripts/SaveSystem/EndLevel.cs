using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace Scripts
{
    public class EndLevel : InteractableObject
    {
        //Variables
        public VideoPlayer endCutscene;

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

                }
            }
        }

        //Custom functions
        public override void interact()
        {
            GameManager.Instance.PlayerCamera.SetActive(false);
            GameManager.Instance.PlayerCameraP2.SetActive(false);
            //GameManager.Instance.CameraFollow.SetActive(false);
            //GameManager.Instance.CameraFollowP2.SetActive(false);
            GameManager.Instance.InteractTextPlayerOne.SetActive(false);
            GameManager.Instance.InteractText.SetActive(false);
            GameManager.Instance.AfterInteractTextPlayerOne.SetActive(false);
            GameManager.Instance.AfterInteractText.SetActive(false);
            GameManager.Instance.Human.SetActive(false);
            GameManager.Instance.Animal.SetActive(false);
            GameManager.Instance.CutsceneCamera.SetActive(true);
            this.endCutscene.Play();
        }
        private void LoadNextLevel()
        {

        }
    }
}