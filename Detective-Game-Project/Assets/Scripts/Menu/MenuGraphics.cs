using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuGraphics : MonoBehaviour
{
    Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown, qualityDropdown;
    public GameObject firstSelect;
    public Toggle windowToggle;


    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        windowToggle.isOn = Screen.fullScreen;


        int QLevel = QualitySettings.GetQualityLevel();
        qualityDropdown.value = QLevel;
        qualityDropdown.RefreshShownValue();


        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        int RLevel = PlayerPrefs.GetInt("GraphicsResolution", currentResolutionIndex);
        resolutionDropdown.value = RLevel;
        resolutionDropdown.RefreshShownValue();
    }


    void OnEnable()
    {
        firstSelect.SetActive(false);
        firstSelect.SetActive(true);
        firstSelect.GetComponent<TMP_Dropdown>().Select();
    }

    public void SetResolutions (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("GraphicsResolution", resolutionIndex);
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex, true);
    }

    public void SetFullscreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
