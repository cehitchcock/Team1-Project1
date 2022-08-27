using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Script_AudioController : MonoBehaviour
{
    // these sources are split so music and SFX volume can be controlled independently.
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
    [SerializeField] AudioClip TileClick;
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
    [SerializeField] string track;

    //singleton pattern for audio controller
    public static Script_AudioController Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Audio_PlayUIClick()
    {
        sourceSFX.PlayOneShot(UIButtonClick, SFXVolume);
    }

    public void Audio_PlayStartSound()
    {
        sourceSFX.PlayOneShot(StartButtonClick, SFXVolume);
    }

    public void Audio_PlayTileMatch(GameObject matchingTiles)
    {
        //tile match needs to know what animals have been matched. This reduces the number of methods needed.

        if (matchingTiles.CompareTag("Cat"))
        {
            sourceSFX.PlayOneShot(CatDeath, SFXVolume);
        }
        else if (matchingTiles.CompareTag("Dog"))
        {
            sourceSFX.PlayOneShot(DogDeath, SFXVolume);
        }
        else if (matchingTiles.CompareTag("Rabbit"))
        {
            sourceSFX.PlayOneShot(RabbitDeath, SFXVolume);
        }
        else if (matchingTiles.CompareTag("Bird"))
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
        else if(soundRoll == 1)
        {
            sourceSFX.PlayOneShot(MatchSoundB, SFXVolume);
        }
        else if(soundRoll == 2)
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


    public void Audio_PlayTileClick(GameObject clickedTile)
    {
        if (clickedTile.CompareTag("Cat"))
        {
            sourceSFX.PlayOneShot(CatSelect, SFXVolume);
        }
        else if (clickedTile.CompareTag("Dog"))
        {
            sourceSFX.PlayOneShot(DogSelect, SFXVolume);
        }
        else if (clickedTile.CompareTag("Rabbit"))
        {
            sourceSFX.PlayOneShot(RabbitSelect, SFXVolume);
        }
        else if (clickedTile.CompareTag("Bird"))
        {
            sourceSFX.PlayOneShot(BirdSelect, SFXVolume);
        }
        else
        {
            //hamster is default
            sourceSFX.PlayOneShot(HamsterSelect, SFXVolume);
        }

        sourceSFX.PlayOneShot(TileClick, SFXVolume);
    }

    public void Audio_PlayScoreSound()
    {
        sourceSFX.PlayOneShot(ScoreSound, SFXVolume);
    }

    public void Audio_PlayGoreExplosion()
    {
        int randomRoll = Random.Range(0 , 3);

        if (randomRoll == 0)
        {
            sourceSFX.PlayOneShot(GoreSoundA, SFXVolume);
        }
        else if (randomRoll == 1)
        {
            sourceSFX.PlayOneShot(GoreSoundB, SFXVolume);
        }
        else
        {
            sourceSFX.PlayOneShot(GoreSoundC, SFXVolume);
        }

    }

    public void Audio_BeginMenuMusc()
    {
        if (track != "menu")
        {
            sourceMusic.Stop();
            sourceMusic.PlayOneShot(menuMusic, musicVolume);
            track = "menu";
        }


    }

    public void Audio_BeginPlayMusic()
    {
        if (track != "play")
        {
            sourceMusic.Stop();
            sourceMusic.PlayOneShot(playMusic, musicVolume);
            track = "play";
        }

    }

    public void Audio_PauseMusic(bool musicIsPaused)
    {
        if (musicIsPaused)
        {
            sourceMusic.Pause();
        }
        else
        {
            sourceMusic.UnPause();
        }
    }
}
