using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class script_menus : MonoBehaviour
{

    public void OnPlayButtonClick()
    {
        SceneManager.LoadScene("scene_1");
    }

    public void OnHelpButtonClick()
    {
        SceneManager.LoadScene("scene_help");
    }

    public void OnCreditsButtonClick()
    {
        SceneManager.LoadScene("scene_credits");
    }

    public void OnMainMenuButtonClick()
    {
        SceneManager.LoadScene("scene_mainmenu");
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }

}
