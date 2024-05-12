using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Windows;

public class Setup_menu_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public Dropdown track_selector;
    public string[] levels_list;
    private string currently_selected_level;
    public void Start()
    {
      

        track_selector.ClearOptions();
        List<string> tracks = new List<string>();
        levels_list = System.IO.Directory.GetFiles("Assets/Scenes/Levels", "*.unity", SearchOption.AllDirectories);
        for(int i =0;  levels_list.Length>i; i++)
        {
            levels_list[i] = Path.GetFileName(levels_list[i]);
            levels_list[i] = levels_list[i].Substring(0, levels_list[i].Length - 6);
            tracks.Add(levels_list[i]);
        }
        track_selector.AddOptions(tracks);
    }
    public void on_dropdown_update()
    {
        currently_selected_level =  track_selector.options[track_selector.value].text;


    }

    public void on_click_back()
    {
        SceneManager.LoadScene("Main_menu");
    }

    public void on_click_start()
    {
        SceneManager.LoadScene(currently_selected_level);

    }
}
