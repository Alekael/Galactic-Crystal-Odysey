using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioMixer musicMixer;
    public void SetVolume(float volume){
        audioMixer.SetFloat("volume", volume);
    }
    public void SetVolumeMusic(float volume){
        musicMixer.SetFloat("volume", volume);
    }
}
