using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_save_load_system
{
    public string car;
    public string track;
    public float time;

    public Score_save_load_system(string curr_car, string curr_track)
    {
        car = curr_car;
        track = curr_track;
    }
    public Score_save_load_system(string curr_car, string curr_track, float curr_time)
    {
        car = curr_car;
        track = curr_track;
        time = curr_time;
    }
    public void Save_data()
    {
        PlayerPrefs.SetFloat(car + track, time);
    }

    public void Load_data()
    {
        time = PlayerPrefs.GetFloat(car + track);
    }
    public float Get_time()
    {
        return time;
    }
}
