using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuMain : MonoBehaviour
{
    public GameObject Play;
    public GameObject NewGame;

    //remove after added
    public GameObject Credits;

    int Unlocked;

    void Start()
    {
        GetLevel();

        if (Unlocked <= 1)
        {
            NewGame.GetComponent<Button>().interactable = false;
        }

        //remove after added
        Credits.GetComponent<Button>().interactable = false;
    }


    void OnEnable()
    {
        GetLevel();

        if (Unlocked <= 1)
        {
            NewGame.GetComponent<Button>().interactable = false;
        }

        // these next 2 lines look completely retarded
        // but they actually fix a stupid bug
        Play.SetActive(false);
        Play.SetActive(true);
        Play.GetComponent<Button>().Select();
    }


    void GetLevel()
    {
        Unlocked = PlayerPrefs.GetInt("Level", 1);
    }


    public void Reset()
    {
        PlayerPrefs.SetInt("Level", 1);

        SceneManager.LoadScene(1);
    }


    public void QuitGame()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false; DON'T USE THIS
    }
}
