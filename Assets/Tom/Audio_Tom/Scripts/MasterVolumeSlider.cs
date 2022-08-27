using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MasterVolumeSlider : MonoBehaviour
{
    //Attach this script to the audio slider in your menu. THE SLIDER VALUE MUST BE MAPPED TO min 0.0001 and max 1

    [SerializeField] Slider masterSlider;
    [SerializeField] AudioMixer masterMixer;
    [SerializeField] float masterLvl;
    void Start()
    {
        ChangeMasterVolume(masterSlider.value);
        masterSlider.onValueChanged.AddListener(val => ChangeMasterVolume(val));
    }

    private void ChangeMasterVolume(float volume)
    {
        masterLvl = volume;
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(masterLvl) * 20);
    }

}
