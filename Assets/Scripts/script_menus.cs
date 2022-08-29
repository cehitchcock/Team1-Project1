using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class script_menus : MonoBehaviour
{
    private void Start()
    {
        Script_AudioController.Instance.isPlaying = false;
    }

    public void OnPlayButtonClick()
    {
        Script_AudioController.Instance.Audio_PlayStartSound();
        SceneManager.LoadScene("scene_1");
    }

    public void OnHelpButtonClick()
    {
        Script_AudioController.Instance.Audio_PlayUIClick();
        SceneManager.LoadScene("scene_help");
    }

    public void OnCreditsButtonClick()
    {
        Script_AudioController.Instance.Audio_PlayUIClick();
        SceneManager.LoadScene("scene_credits");
    }

    public void OnMainMenuButtonClick()
    {
        Script_AudioController.Instance.Audio_PlayUIClick();
        SceneManager.LoadScene("scene_mainmenu");
    }

    public void OnQuitButtonClick()
    {
        Script_AudioController.Instance.Audio_PlayUIClick();
        Application.Quit();
    }

}
