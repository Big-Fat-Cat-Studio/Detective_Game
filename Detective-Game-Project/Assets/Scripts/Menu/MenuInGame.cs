using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Scripts
{
    public class MenuInGame : MonoBehaviour
    {
        public GameObject Resume;
        // Start is called before the first frame update
        void Start()
        {
            // Resume.SetActive(false);
            // Resume.SetActive(true);
            Resume.GetComponent<UnityEngine.UI.Button>().Select();
        }

        // Update is called once per frame
        void OnEnable()
        {
            Resume.SetActive(false);
            Resume.SetActive(true);
            Resume.GetComponent<UnityEngine.UI.Button>().Select();
        }

        public void ResumeLevel()
        {
            Time.timeScale = 1;
        }

        public void ResetLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void MainMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}