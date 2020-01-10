using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuInGame : MonoBehaviour
{
    public GameObject Resume;
    // Start is called before the first frame update
    void Start()
    {
        // Resume.SetActive(false);
        // Resume.SetActive(true);
        Resume.GetComponent<Button>().Select();
    }

    // Update is called once per frame
    void OnEnable()
    {
        Resume.SetActive(false);
        Resume.SetActive(true);
        Resume.GetComponent<Button>().Select();
    }

    public void ResumeLevel()
    {
        // HOI LEON, HIER GRAAG PLAYER INPUT WEER AANZETTEN
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
