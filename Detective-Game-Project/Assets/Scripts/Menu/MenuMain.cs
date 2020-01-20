using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuMain : MonoBehaviour
{
    public GameObject Play, NewGame, Options, Credits, Exit, bookImageLeft, bookImageRight;

    public string creditsScene;

    int Unlocked;

    void Start()
    {
        PlayerPrefs.SetInt("Level", 3);
        Unlocked = PlayerPrefs.GetInt("Level");
        GetLevel();

        if (Unlocked <= 1)
        {
            NewGame.GetComponent<Button>().interactable = false;
        }
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

    public void MenuDisable()
    {
        Play.GetComponent<Button>().interactable = false;
        NewGame.GetComponent<Button>().interactable = false;
        Options.GetComponent<Button>().interactable = false;
        Credits.GetComponent<Button>().interactable = false;
        Exit.GetComponent<Button>().interactable = false;
    }

    public void MenuEnable()
    {
        Play.GetComponent<Button>().interactable = true;
        if (Unlocked > 1)
        {
            NewGame.GetComponent<Button>().interactable = true;
        }
        Options.GetComponent<Button>().interactable = true;
        Credits.GetComponent<Button>().interactable = true;
        Exit.GetComponent<Button>().interactable = true;

        Play.GetComponent<Button>().Select();
    }

    public void Darken()
    {
        bookImageLeft.GetComponent<Image>().color = Color.grey;
        bookImageRight.GetComponent<Image>().color = Color.grey;
    }

    public void Lighten()
    {
        bookImageLeft.GetComponent<Image>().color = Color.white;
        bookImageRight.GetComponent<Image>().color = Color.white;
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

    public void PlayCredits()
    {
        SceneManager.LoadScene(creditsScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
