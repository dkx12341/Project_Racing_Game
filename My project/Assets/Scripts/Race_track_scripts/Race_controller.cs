using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

//Class controlls main elements of race, such as start, finish, various menus ect.
public class Race_controller : MonoBehaviour
{
    public bool all_checkpoints_true = false;
    public Dictionary<GameObject, bool> checkpoint_list = new Dictionary<GameObject, bool>();

    private Transform checkpoint_list_raw;
    private GameObject start_line;
    private GameObject finish_line;
    private Collider collision;

    public SO_best_time Best_time;
    public SO_string Selected_car;
    public SO_int Selected_laps;
    public SO_string Selected_track;

    public int finished_laps = 0;
    public GameObject Finished_game_menu;
    public Race_timer Race_timer;


    void Start()
    {
       
        start_line = GameObject.FindWithTag("Start_line");
        finish_line = GameObject.FindWithTag("Finish_line");
        Finished_game_menu = GameObject.FindWithTag("Finished_game_menu");
        Race_timer = GameObject.FindWithTag("Race_timer").GetComponent<Race_timer>();

        checkpoint_list_raw = GameObject.FindWithTag("Checkpoints_list").transform;
        foreach (Transform checkpoint in checkpoint_list_raw)
        {
            checkpoint_list.Add(checkpoint.gameObject, false);
        }
    }
    public Collider Detect_collision
    {
        get
        {
            return collision;
        }

        set
        {
            collision = value;
            OnCollision(collision);
        }
    }
    void OnCollision(Collider other)
    {

        if (other.gameObject == start_line)
        {
            on_start_line_collision(other);
        }
        else if (other.gameObject == finish_line)
        {

            on_finish_line_collision(other);
        }

        if (checkpoint_list.ContainsKey(other.gameObject))
        {
            on_checkpoint_collision(other);
        }

    }
    public bool check_if_all_ckeckpoints_true()
    {
        bool ret_val = true;
        foreach (KeyValuePair<GameObject, bool> checkpoint in checkpoint_list)
        {
            if (checkpoint.Value == false)
            {
                ret_val = false;
            }
        }
        return ret_val;
    }

    void on_checkpoint_collision(Collider other)
    {
        other.gameObject.GetComponent<MeshRenderer>().enabled = false;
        checkpoint_list[other.gameObject] = true;
        all_checkpoints_true = check_if_all_ckeckpoints_true();
    }

    void on_start_line_collision(Collider other)
    {
        if (Race_timer.start_timer == false)
        {
            Race_timer.start_timer = true;
        }
    }

    void on_finish_line_collision(Collider other)
    {
        if (Race_timer.start_timer == true && all_checkpoints_true == true)
        {
            finished_laps++;
            if (finished_laps < Selected_laps.Val)
            {
                List<GameObject> checkpoints = new List<GameObject>(checkpoint_list.Keys);
                foreach (GameObject i in checkpoints)
                {
                    checkpoint_list[i] = false;
                    i.GetComponent<MeshRenderer>().enabled = true;
                }
                all_checkpoints_true = false;
            }
            else
            {
                Race_timer.start_timer = false;
                Score_save_load_system save_load_System = new Score_save_load_system(Selected_car.Str, Selected_track.Str, Selected_laps.Val);
                save_load_System.Load_data();
                if (save_load_System.Get_time() > Race_timer.lap_time || save_load_System.Get_time() == 0)
                {
                    Finished_game_menu.GetComponent<Finished_game_menu_controller>().is_new_record = true;
                    save_load_System.Set_time(Race_timer.lap_time);
                    save_load_System.Save_data();
                }
                else
                {
                    Finished_game_menu.GetComponent<Finished_game_menu_controller>().is_new_record = false;
                }
                Finished_game_menu.GetComponent<Finished_game_menu_controller>().final_time = Race_timer.lap_time;
                Finished_game_menu.GetComponent<Finished_game_menu_controller>().game_is_finished = true;
            }
        }

    }

   
}


