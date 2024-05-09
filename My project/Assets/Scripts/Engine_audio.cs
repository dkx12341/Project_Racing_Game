using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine_audio : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource Running_sound;
    public float Running_max_volume;
    public float Running_max_pitch;

    public AudioSource Idle_sound;
    public float Idle_max_volume;
    public float Idle_max_pitch;
    public float engine_usage;
    public float volume;

    private Player_car_controller car_Controller;
    void Start()
    {
        car_Controller = GetComponent<Player_car_controller>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (car_Controller)
        {
            engine_usage = car_Controller.Get_engine_usage();
        }

        Idle_sound.volume = Mathf.Lerp(0.1f, Idle_max_volume, engine_usage) * volume;
        Running_sound.volume = Mathf.Lerp(0.3f, Running_max_volume, engine_usage) * volume;
        Running_sound.pitch = Mathf.Lerp(0.3f, Running_max_pitch, engine_usage);

    }
}
