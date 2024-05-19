using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class SO_best_time : ScriptableObject
{
    [SerializeField]

    private float best_time;
    private bool time_set = false;

    public float Best_time
    {
        get { return best_time; }
        set { best_time = value; }
    }

    public bool Time_set
    {
        get { return time_set; }
        set { time_set = value; }
    }
}
