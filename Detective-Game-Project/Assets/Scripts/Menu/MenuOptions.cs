using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{
    //remove after added
    public GameObject Resume, Graphics, Sound, Controls, Language;

    // void Start()
    // {
    //     // //remove after added
    //     Sound.GetComponent<Button>().interactable = false;
    //     // Controls.GetComponent<Button>().interactable = false;
    //     Language.GetComponent<Button>().interactable = false;
    // }
    public void MenuReturn()
    {
        Resume.GetComponent<Button>().Select();
    }

    public void MenuDisable()
    {
        Resume.GetComponent<Button>().interactable = false;
        Graphics.GetComponent<Button>().interactable = false;
        Sound.GetComponent<Button>().interactable = false;
        Controls.GetComponent<Button>().interactable = false;
        Language.GetComponent<Button>().interactable = false;
    }

    public void MenuEnable()
    {
        Resume.GetComponent<Button>().interactable = true;
        Graphics.GetComponent<Button>().interactable = true;
        // Sound.GetComponent<Button>().interactable = true;
        Controls.GetComponent<Button>().interactable = true;
        // Language.GetComponent<Button>().interactable = true;
    }

    void OnEnable()
    {
        // //remove after added
        Sound.GetComponent<Button>().interactable = false;
        // Controls.GetComponent<Button>().interactable = false;
        Language.GetComponent<Button>().interactable = false;
        Resume.GetComponent<Button>().Select();
    }
}
