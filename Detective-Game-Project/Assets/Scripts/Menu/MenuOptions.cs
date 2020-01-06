using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{
    //remove after added
    public GameObject Resume, Graphics, Sound, Controls, Language;

    void Start()
    {
        // //remove after added
        Graphics.GetComponent<Button>().interactable = false;
        Sound.GetComponent<Button>().interactable = false;
        Controls.GetComponent<Button>().interactable = false;
        Language.GetComponent<Button>().interactable = false;
    }


    void OnEnable()
    {
        //remove after added
        Resume.GetComponent<Button>().Select();
    }
}
