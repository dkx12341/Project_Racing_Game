using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_save_load_system
{
    public string car;
    public string track;
    public int laps;
    public float time;

    public Score_save_load_system(string curr_car, string curr_track, int curr_laps)
    {
        car = curr_car;
        track = curr_track;
        laps = curr_laps;
    }
    public void Save_data()
    {

        PlayerPrefs.SetFloat(car + track + laps , time);
    }

    public void Load_data()
    {
        time = PlayerPrefs.GetFloat(car + track + laps);
    }
    public void Set_time(float t)
    {
        time = t;
    }
    public float Get_time()
    {
        return time;
    }
}
