using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace Scripts
{
    public class ShowTutorialOnStart : Tutorial, ISkipable
    {
        public VideoPlayer intro;
        private bool cutscenePlayed = false;

        void Start()
        {
            GameManager.Instance.PlayerCamera.SetActive(false);
            GameManager.Instance.PlayerCameraP2.SetActive(false);
            GameManager.Instance.InteractTextP1.SetActive(false);
            GameManager.Instance.InteractTextP2.SetActive(false);
            GameManager.Instance.AfterInteractTextP1.SetActive(false);
            GameManager.Instance.AfterInteractTextP2.SetActive(false);
            GameManager.Instance.Human.GetComponent<CharacterController>().enabled = false;
            GameManager.Instance.Animal.GetComponent<CharacterController>().enabled = false;
            GameManager.Instance.Human.GetComponent<AudioListener>().enabled = false;
            GameManager.Instance.CutsceneCamera.SetActive(true);
            intro.Play();
            StartCoroutine(VideoChecker());
        }
        private IEnumerator VideoChecker()
        {
            WaitForSeconds timer = new WaitForSeconds(1.0f);
            for(; ; )
            {
                yield return timer;
                if(!intro.isPlaying)
                {
                    EndCutscene();
                    break;
                }
            }
        }
        public void Skip()
        {
            EndCutscene();
        }

        private void EndCutscene()
        {
            if (!cutscenePlayed)
            {
                cutscenePlayed = true;
                GameManager.Instance.CutsceneCamera.SetActive(false);
                GameManager.Instance.PlayerCamera.SetActive(true);
                GameManager.Instance.PlayerCameraP2.SetActive(true);
                GameManager.Instance.Human.GetComponent<CharacterController>().enabled = true;
                GameManager.Instance.Animal.GetComponent<CharacterController>().enabled = true;
                GameManager.Instance.Human.GetComponent<AudioListener>().enabled = true;
                Pause();
            }
        }
    }
}