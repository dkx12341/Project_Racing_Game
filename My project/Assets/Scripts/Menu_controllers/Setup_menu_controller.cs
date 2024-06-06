using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Setup_menu_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Dropdown track_selector;
    public TMP_Dropdown car_selector;
    //public Scene[] levels_list;
    public UnityEngine.Object[] cars_list;
    private string currently_selected_level;
    public SO_string Selected_car;
    public void Start()
    {
        
        track_selector.ClearOptions();
        List<string> tracks = new List<string>();
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        string[] all_scenes_list = new string[sceneCount];

        for (int i = 0; i < sceneCount; i++)
        {
            all_scenes_list[i] = Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
        }

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
    

        car_selector.ClearOptions();
        List<string> cars = new List<string>();
        cars_list = Resources.LoadAll("Prefabs/Cars");

        for (int i = 0; cars_list.Length > i; i++)
        {
            cars.Add(cars_list[i].name);
        }
        car_selector.AddOptions(cars);
        Selected_car.Str = cars[0];
    }
    public void on_dropdown_update()
    {
        currently_selected_level = "track_" + track_selector.options[track_selector.value].text;
        Selected_car.Str = car_selector.options[car_selector.value].text;

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

