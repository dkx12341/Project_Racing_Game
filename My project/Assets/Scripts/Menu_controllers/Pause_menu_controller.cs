using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_menu_controller : MonoBehaviour
{
    static bool Pause_menu_active = false;
    public GameObject pause_menu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)==true)
        {
            if(Pause_menu_active == true)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }

    public void pause()
    {
        pause_menu.SetActive(true);
        Pause_menu_active = true;
        Time.timeScale = 0f;
    }
    public void resume()
    {
        pause_menu.SetActive(false);
        Pause_menu_active = false;
        Time.timeScale = 1f;
    }
    public void on_main_menu_button()
    {
        SceneManager.LoadScene("Main_menu");
    }

    public void on_resume_button()
    {
        resume();
    }
}
