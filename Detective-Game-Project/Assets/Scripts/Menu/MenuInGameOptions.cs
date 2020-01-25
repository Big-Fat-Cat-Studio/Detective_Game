using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class MenuInGameOptions : MonoBehaviour
{
    public Toggle windowToggle;
    public AudioMixer audioMixer;
    public Slider musicSlider, soundSlider;
    AudioSource audioSource;

    void Start()
    {
        windowToggle.isOn = Screen.fullScreen;

        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        soundSlider.value = PlayerPrefs.GetFloat("SoundVolume", 0.75f);
    }

    public void SetFullscreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetMusicVolume (float musicVolume)
    {
        audioMixer.SetFloat("musicVolume", Mathf.Log10(musicVolume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
    }

    public void SetSoundVolume (float soundVolume)
    {
        audioMixer.SetFloat("soundVolume", Mathf.Log10(soundVolume) * 20);
        PlayerPrefs.SetFloat("SoundVolume", soundVolume);
    }
}
