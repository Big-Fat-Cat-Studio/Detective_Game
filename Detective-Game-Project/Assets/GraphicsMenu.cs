using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GraphicsMenu : MonoBehaviour
{
    public AudioMixer MasterMixer;
    public Dropdown ResolutionDrop;

    private void Start()
    {
        ResolutionDrop.ClearOptions(); 
        Resolution[] currentResolutions = Screen.resolutions;

        List<string> resolutions = new List<string>();
        foreach (Resolution r in currentResolutions)
            resolutions.Add($"{r.width}x{r.height}");
        ResolutionDrop.AddOptions(resolutions);

        //TODO(HAMZA):: Add handler for the resolution scrollbar.
    }

    public void SetVolume(float volume)
    {
        MasterMixer.SetFloat("Volume", volume);
    }

    public void SetQuality(int i)
    {
        QualitySettings.SetQualityLevel(i);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
