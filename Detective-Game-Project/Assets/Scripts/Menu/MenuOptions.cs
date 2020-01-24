using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuOptions : MonoBehaviour
{
    public GameObject Resume, Graphics, Sound, Controls, Language;

    public void MenuReturn()
    {
        Graphics.GetComponent<Button>().Select();
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
        Sound.GetComponent<Button>().interactable = true;
        Controls.GetComponent<Button>().interactable = true;
        Language.GetComponent<Button>().interactable = true;
    }

    void OnEnable()
    {
        Graphics.SetActive(false);
        Graphics.SetActive(true);
        Graphics.GetComponent<Button>().Select();
    }
}
