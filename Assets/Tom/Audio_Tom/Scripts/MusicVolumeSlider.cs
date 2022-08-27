using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MusicVolumeSlider : MonoBehaviour
{
    //Attach this script to the audio slider in your menu. THE SLIDER VALUE MUST BE MAPPED TO min 0.0001 and max 1

    [SerializeField] Slider musicSlider;
    [SerializeField] AudioMixer musicMixer;
    [SerializeField] float musicLvl;
    void Start()
    {
        ChangeMusicVolume(musicSlider.value);
        musicSlider.onValueChanged.AddListener(val => ChangeMusicVolume(val));
    }

    private void ChangeMusicVolume(float volume)
    {
        musicLvl = volume;
        musicMixer.SetFloat("MusicVolume", Mathf.Log10(musicLvl) * 20);
    }

}
