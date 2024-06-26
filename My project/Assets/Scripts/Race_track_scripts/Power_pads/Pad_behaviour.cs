using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;

public class Pad_behaviour : MonoBehaviour
{
    private float change_time = 2f;
    public float time_since_change = 0f;
    public int i = 1;
    public Material[] colours;

    public Pad_power currenty_active_power;

    public List<Pad_power> pads_list = new List<Pad_power>();

    public MeshRenderer pad_renderer;
    private void Update()
    {

        time_since_change += Time.deltaTime;
        cycle_pad_powers();


    }
    private void Start()
    {
        pads_list.Add(new Slow_down_pad_power());
        pads_list.Add(new Speed_up_pad_power());
        pads_list.Add(new Slippery_pad_power());
        pad_renderer = this.gameObject.GetComponent<MeshRenderer>();

        currenty_active_power = pads_list[0];
        pad_renderer.material = colours[0];

    }

    private void OnTriggerEnter(Collider other)
    {
        currenty_active_power.apply_pad_power(other);
    }

    private void cycle_pad_powers()
    {       
        if (time_since_change >= change_time)
        {
            currenty_active_power = pads_list[i];
            pad_renderer.material = colours[i];
            //Waiter.Wait(change_time, () => { });

            if (i == 2)
            {
                i = 0;
            }
            else
            {
                i++;
            }
            time_since_change = 0;
        }
        
    }
}
