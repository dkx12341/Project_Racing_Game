using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class Options_menu_controller : MonoBehaviour
{
    public AudioMixer audio_mixer;
    public void change_volume(float vol)
    {
        audio_mixer.SetFloat("Main_volume", vol);
    }
    public void on_back_button()
    {
        SceneManager.LoadScene("Main_menu");
    }

}
