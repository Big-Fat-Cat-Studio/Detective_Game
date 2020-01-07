using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuMain : MonoBehaviour
{
    public GameObject Play;
    public GameObject newGame;

    //remove after added
    public GameObject Credits;

    void Start()
    {
        // Resume.GetComponent<Button>().interactable = false; // Only disabled when playing for the very first time

        //remove after added
        Credits.GetComponent<Button>().interactable = false;
        newGame.GetComponent<Button>().interactable = false;
    }


    void OnEnable()
    {
        // these next 2 lines look completely retarded
        // but they actually fix a stupid bug
        Play.SetActive(false);
        Play.SetActive(true);
        Play.GetComponent<Button>().Select();
    }


    public void NewGame()
    {
        // Start from scratch

        // Should throw prompt warning for loss of save game

        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);

        SceneManager.LoadScene(1);
    }


    public void QuitGame()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false; DON'T USE THIS
    }
}
