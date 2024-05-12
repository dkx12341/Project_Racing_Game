using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_menu_controller : MonoBehaviour
{
    public void on_play_button()
    {
        SceneManager.LoadScene("Race_setup_menu");
    }
    public void on_options_button()
    {
        SceneManager.LoadScene("Options_menu");
    }
    public void on_exit_button()
    {
        Application.Quit();
    }

}

