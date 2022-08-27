using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SFXVolumeSlider : MonoBehaviour
{
    //Attach this script to the audio slider in your menu. THE SLIDER VALUE MUST BE MAPPED TO min 0.0001 and max 1

    [SerializeField] Slider sfxSlider;
    [SerializeField] AudioMixer sfxMixer;
    [SerializeField] float sfxLvl;
    void Start()
    {
        ChangeSfxVolume(sfxSlider.value);
        sfxSlider.onValueChanged.AddListener(val => ChangeSfxVolume(val));
    }

    private void ChangeSfxVolume(float volume)
    {
        sfxLvl = volume;
        sfxMixer.SetFloat("SFXVolume", Mathf.Log10(sfxLvl) * 20);
    }
}
