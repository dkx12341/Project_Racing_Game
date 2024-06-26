using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Setup_menu_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Dropdown track_selector;
    public TMP_Dropdown car_selector;
    public TMP_Dropdown laps_selector;
    public TMP_InputField nick;
    public TMP_Text best_time;
    //public Scene[] levels_list;
    public UnityEngine.Object[] cars_list;
    private string currently_selected_level;
    public SO_string Selected_car;
    public SO_string Selected_track;
    public SO_int Selected_laps;
    public bool good_nick = false;
    public void Start()
    {
        track_selector.ClearOptions();
        car_selector.ClearOptions();

        List<string> tracks = new List<string>();
        
        string[] all_scenes_list = get_all_scene_names();

        for (int i = 0; i < all_scenes_list.Length; i++)
        {
            string scene_name = all_scenes_list[i];
            if (scene_name.Substring(0,6) == "track_")
            {
                tracks.Add(scene_name.Substring(6));
            }
        }
        track_selector.AddOptions(tracks);
        currently_selected_level = "track_" + tracks[0];
    
        
        List<string> cars = new List<string>();
        cars_list = Resources.LoadAll("Prefabs/Cars");

        for (int i = 0; cars_list.Length > i; i++)
        {
            cars.Add(cars_list[i].name);
        }
        car_selector.AddOptions(cars);
        Selected_car.Str = cars[0];


        Selected_laps.Val = Int16.Parse(laps_selector.options[laps_selector.value].text);
        get_best_time();
    }
    private void get_best_time()
    {
        Score_save_load_system load_System = new Score_save_load_system(Selected_car.Str, Selected_track.Str, Selected_laps.Val);
        load_System.Load_data();
        if (load_System.Get_time() != 0)
        {
            best_time.text = "Best time:\n" + load_System.Get_time().ToString("f2");
        }
        else
        {
            best_time.text = "Best time:\n--:--";
        }
    }
    private string[] get_all_scene_names()
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        string[] all_scenes_list = new string[sceneCount];
        for (int i = 0; i < sceneCount; i++)
        {
            all_scenes_list[i] = Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
        }
        return all_scenes_list;
    }
    public void on_dropdown_update()
    {
        currently_selected_level = "track_" + track_selector.options[track_selector.value].text;
        Selected_track.Str = currently_selected_level;
        Selected_car.Str = car_selector.options[car_selector.value].text;
        Selected_laps.Val = Int32.Parse(laps_selector.options[laps_selector.value].text);
       
        get_best_time();
    }
    
    public void on_click_back()
    {
        SceneManager.LoadScene("Main_menu");
    }

    public void on_click_start()
    {
        if (good_nick == true)
        {
            SceneManager.LoadScene(currently_selected_level);
        }

    }

    public void on_nick_value_changed()
    {
        string pattern = @"^[a-zA-Z0-9]{1,20}$";
        Regex regex = new Regex(pattern);

        string input = nick.text; // Zamieñ na dowolny tekst do przetestowania

        if (regex.IsMatch(input))
        {
            good_nick = true;
        }
    }
}

