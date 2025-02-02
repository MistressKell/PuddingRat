using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public AudioMixer mymixer;
    public Slider musicSlider;
    public Slider SFXSlider;

    void Start()
    {
        setMusicVolume();
        setSFXVolume();
    }
    
    public void setMusicVolume()
    {
        float volume = musicSlider.value;
        mymixer.SetFloat("music", volume);
    }

    public void setSFXVolume()
    {
        float volume = SFXSlider.value;
        mymixer.SetFloat("sfx", volume);
    }

    public void setFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
