using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class tester : MonoBehaviour
{
    [Header("Audio sources")]
    [SerializeField] AudioSource sourceSFX;
    [SerializeField] AudioSource sourceMusic;
    [Space(10)]
    [Header("Audio mixer")]
    [SerializeField] AudioMixer audioMixer;
    [Space(10)]
    [Header("Volume Levels")]
    [SerializeField] float SFXVolume = 1.0f;
    [SerializeField] float musicVolume = 1.0f;
    [Range(-80, 20)] [SerializeField] float MasterVolumeMixer = 0;
    [Range(-80, 20)] [SerializeField] float SFXVolumeMixer = 0;
    [Range(-80, 20)] [SerializeField] float MusicVolumeMixer = 0;
    [Space(10)]
    [Header("SFX Tracks")]
    [SerializeField] AudioClip UIButtonClick;
    [SerializeField] AudioClip StartButtonClick;
    [SerializeField] AudioClip HamsterSelect;
    [SerializeField] AudioClip HamsterDeath;
    [SerializeField] AudioClip DogSelect;
    [SerializeField] AudioClip DogDeath;
    [SerializeField] AudioClip CatSelect;
    [SerializeField] AudioClip CatDeath;
    [SerializeField] AudioClip BirdSelect;
    [SerializeField] AudioClip BirdDeath;
    [SerializeField] AudioClip RabbitSelect;
    [SerializeField] AudioClip RabbitDeath;
    [SerializeField] AudioClip ScoreSound;
    [SerializeField] AudioClip MatchSoundA;
    [SerializeField] AudioClip MatchSoundB;
    [SerializeField] AudioClip MatchSoundC;
    [SerializeField] AudioClip MatchSoundD;
    [SerializeField] AudioClip GoreSoundA;
    [SerializeField] AudioClip GoreSoundB;
    [SerializeField] AudioClip GoreSoundC;
    [Space(10)]
    [Header("Music tracks")]
    [SerializeField] AudioClip menuMusic;
    [SerializeField] AudioClip playMusic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Audio_TileMatch();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            //Script_AudioController.Instance.Audio_BeginMenuMusc();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            //Script_AudioController.Instance.Audio_BeginPlayMusic();
        }
    }

    public void Audio_TileMatch()
    {
        //tile match needs to know what animals have been matched. This reduces the number of methods needed.
        int animalRoll = Random.Range(0, 5);

        if (animalRoll == 0)
        {
            sourceSFX.PlayOneShot(CatDeath, SFXVolume);
        }
        else if (animalRoll == 1)
        {
            sourceSFX.PlayOneShot(DogDeath, SFXVolume);
        }
        else if (animalRoll == 2)
        {
            sourceSFX.PlayOneShot(RabbitDeath, SFXVolume);
        }
        else if (animalRoll == 3)
        {
            sourceSFX.PlayOneShot(BirdDeath, SFXVolume);
        }
        else
        {
            //hamster is default
            sourceSFX.PlayOneShot(HamsterDeath, SFXVolume);
        }


        //GENERATE RANDOM INT FOR RANDOM MATCH SOUND.
        int soundRoll = Random.Range(0, 4);

        if (soundRoll == 0)
        {
            sourceSFX.PlayOneShot(MatchSoundA, SFXVolume);
        }
        else if (soundRoll == 1)
        {
            sourceSFX.PlayOneShot(MatchSoundB, SFXVolume);
        }
        else if (soundRoll == 2)
        {
            sourceSFX.PlayOneShot(MatchSoundC, SFXVolume);
        }
        else if (soundRoll == 3)
        {
            sourceSFX.PlayOneShot(MatchSoundD, SFXVolume);
        }
        else
        {
            sourceSFX.PlayOneShot(MatchSoundA, SFXVolume);
        }

    }
}
