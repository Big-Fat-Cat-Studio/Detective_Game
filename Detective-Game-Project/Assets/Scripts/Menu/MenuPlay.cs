using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPlay : MonoBehaviour
{
    public GameObject Level4, Level3, Level2, Level1, Target;
    public Sprite[] imageArray;
    int Unlocked = 1;


    void OnEnable()
    {
        if (Unlocked >= 1)
        {
            Level1.GetComponent<Button>().Select();
            // Level1.GetComponentInChildren<Text>().text = "House";
            // Target.GetComponent<Image>().sprite = imageArray[0];
            Level1.GetComponentInChildren<Text>().text = "Docks";
            Target.GetComponent<Image>().sprite = imageArray[3];
        }

        if (Unlocked >= 2)
        {
            Level2.GetComponent<Button>().Select();
            Level2.GetComponentInChildren<Text>().text = "Office";
            Level2.GetComponent<Button>().interactable = true;
            Target.GetComponent<Image>().sprite = imageArray[1];
        }

        if (Unlocked >= 3)
        {
            Level3.GetComponent<Button>().Select();
            Level3.GetComponentInChildren<Text>().text = "Subway";
            Level3.GetComponent<Button>().interactable = true;
            Target.GetComponent<Image>().sprite = imageArray[2];
        }

        if (Unlocked >= 4)
        {
            Level4.GetComponent<Button>().Select();
            Level4.GetComponentInChildren<Text>().text = "Docks";
            Level4.GetComponent<Button>().interactable = true;
            Target.GetComponent<Image>().sprite = imageArray[3];
        }
    }

    public void LoadLevel1()
    {
        // SceneManager.LoadScene(1);
        SceneManager.LoadScene(2);
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene(88);
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene(88);
    }

    public void LoadLevel4()
    {
        SceneManager.LoadScene(2);
    }
}
