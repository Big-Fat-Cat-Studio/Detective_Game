using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuLanguage : MonoBehaviour
{
    public TMP_Dropdown dropdownLanguage;

    public void SetLanguage()
    {
        string newLanguage = dropdownLanguage.options[dropdownLanguage.value].text;
        switch (newLanguage)
        {
            case "Deutch":
                PlayerPrefs.SetString("Language", "DE");
                break;
            case "Dansk":
                PlayerPrefs.SetString("Language", "DK");
                break;
            case "English":
                PlayerPrefs.SetString("Language", "UK");
                break;
            case "Español":
                PlayerPrefs.SetString("Language", "ES");
                break;
            case "Français":
                PlayerPrefs.SetString("Language", "FR");
                break;
            case "Nederlands":
                PlayerPrefs.SetString("Language", "NL");
                break;
            case "Português":
                PlayerPrefs.SetString("Language", "PT");
                break;
            case "Türk":
                PlayerPrefs.SetString("Language", "TR");
                break;
        }
    }

    public void GetLanguage()
    {
        string savedLanguage = PlayerPrefs.GetString("Language", "UK");
        switch (savedLanguage)
        {
            case "DE":
                Cycle("Deutch");
                break;
            case "DK":
                Cycle("Dansk");
                break;
            case "UK":
                Cycle("English");
                break;
            case "ES":
                Cycle("Español");
                break;
            case "FR":
                Cycle("Français");
                break;
            case "NL":
                Cycle("Nederlands");
                break;
            case "PT":
                Cycle("Português");
                break;
            case "TR":
                Cycle("Türk");
                break;
        }
    }

    public void Cycle(string lang)
    {
        int index = 0;
        foreach(TMP_Dropdown.OptionData option in dropdownLanguage.options)
        {
            // Debug.Log(option.text);
            // Debug.Log(index);
            if (option.text == lang)
            {
                dropdownLanguage.value = index;
                dropdownLanguage.RefreshShownValue();
            }
            index++;
        }
    }
}
