using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Track_selection_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public SO_string Selected_track;
    public SO_int Selected_laps;

    private string currently_viewed_track;

    private List<string> tracks = new List<string>();

    private int currently_viewed_track_num = 0;

    public Image currently_viewed_track_sprite;
    void Start()
    {
        List<string> tracks = new List<string>();

        string[] all_scenes_list = get_all_scene_names();

        for (int i = 0; i < all_scenes_list.Length; i++)
        {
            string scene_name = all_scenes_list[i];
            if (scene_name.Substring(0, 6) == "track_")
            {
                tracks.Add(scene_name.Substring(6));
            }
        }
        
        currently_viewed_track = "track_" + tracks[currently_viewed_track_num];
        update_viewed_track();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void update_viewed_track()
    {
        currently_viewed_track_sprite.sprite = Resources.Load<Sprite>("Sprites/Track_sprites/" + currently_viewed_track);
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

    public void On_left_button()
    {
        if (currently_viewed_track_num != 0)
        {
            currently_viewed_track_num = currently_viewed_track_num - 1;
        }
        else
        {
            currently_viewed_track_num = tracks.Count - 1;
        }
        update_viewed_track();
    }

    public void On_right_button()
    {
        if (currently_viewed_track_num != tracks.Count - 1)
        {
            currently_viewed_track_num = currently_viewed_track_num + 1;
        }
        else
        {
            currently_viewed_track_num = 0;
        }
        update_viewed_track();
    }



}
