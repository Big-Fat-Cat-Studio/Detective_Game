using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuPlay : MonoBehaviour
{
    public GameObject Level4, Level3, Level2, Level1, Target;
    public Sprite[] imageArray;
    int Unlocked, UnlockedCheat;

    //TODO(HAMZA): Improve if we ever continue working on this.
    private string CurrentCheat;
    public enum MENUCHEATS { UNLOCKLEVELS = 1337 };


    void Update()
    {
        if (Input.inputString.Length > 0)
        {
            CurrentCheat += Input.inputString;
            if (CurrentCheat.Contains($"{(int)MENUCHEATS.UNLOCKLEVELS}"))
            {
                // Reset cheat counter
                CurrentCheat = "";
                // Perform cheat
                UnlockedCheat = 1;
                OnEnable();
            }
        }
    }

    void OnEnable()
    {
        GetLevel();

        // these next 2 lines look completely retarded
        // but they actually fix a stupid bug


        if (Unlocked >= 1 || UnlockedCheat > 0)
        {
            Level1.SetActive(false);
            Level1.SetActive(true);
            Level1.GetComponent<Button>().Select();
            Level1.GetComponentInChildren<TMP_Text>().text = "Grandpa's garden";
            Target.GetComponent<Image>().sprite = imageArray[0];
        }

        if (Unlocked >= 2 || UnlockedCheat > 0)
        {
            Level2.SetActive(false);
            Level2.SetActive(true);
            Level2.GetComponent<Button>().interactable = true;
            Level2.GetComponent<Button>().Select();
            Level2.GetComponentInChildren<TMP_Text>().text = "Grandpa's office";
            Target.GetComponent<Image>().sprite = imageArray[1];
        }

        if (Unlocked >= 3 || UnlockedCheat > 0)
        {
            Level3.SetActive(false);
            Level3.SetActive(true);
            Level3.GetComponent<Button>().interactable = true;
            Level3.GetComponent<Button>().Select();
            Level3.GetComponentInChildren<TMP_Text>().text = "The warehouse";
            Target.GetComponent<Image>().sprite = imageArray[2];
        }

        // if (Unlocked >= 4 || UnlockedCheat > 0)
        // {
        //     Level4.SetActive(false);
        //     Level4.SetActive(true);
        //     Level4.GetComponent<Button>().interactable = true;
        //     Level4.GetComponent<Button>().Select();
        //     Level4.GetComponentInChildren<TMP_Text>().text = "Subway";
        //     Target.GetComponent<Image>().sprite = imageArray[3];
        // }
    }

    void GetLevel()
    {
        Unlocked = PlayerPrefs.GetInt("Level", 1);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene(3);
    }

    // public void LoadLevel4()
    // {
    //     SceneManager.LoadScene(4);
    // }
}
