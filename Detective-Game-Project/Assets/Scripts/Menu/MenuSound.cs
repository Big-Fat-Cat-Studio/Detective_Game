using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuSound : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider musicSlider, soundSlider;
    AudioSource audioSource;
    public GameObject shutUpDog;

    void Start()
    {
        shutUpDog.GetComponent<AudioSource>().mute = true;
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        soundSlider.value = PlayerPrefs.GetFloat("SoundVolume", 0.75f);
        Invoke("Unmute", 0.4f);
    }

    public void SetMusicVolume (float musicVolume)
    {
        audioMixer.SetFloat("musicVolume", Mathf.Log10(musicVolume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
    }

    public void SetSoundVolume (float soundVolume)
    {
        // shutUpDog.GetComponent<AudioSource>().mute = false;
        audioMixer.SetFloat("soundVolume", Mathf.Log10(soundVolume) * 20);
        PlayerPrefs.SetFloat("SoundVolume", soundVolume);
    }

    void Unmute()
    {
        shutUpDog.GetComponent<AudioSource>().mute = false;
    }
}
