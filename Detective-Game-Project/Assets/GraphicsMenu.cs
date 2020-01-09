using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GraphicsMenu : MonoBehaviour
{
    public AudioMixer MasterMixer;

    public void SetVolume(float v)
    {
        MasterMixer.SetFloat("Volume", v);
    } 
}
