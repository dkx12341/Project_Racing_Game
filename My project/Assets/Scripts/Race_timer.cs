using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Race_timer : MonoBehaviour
{
    public bool start_timer = false;
    public float lap_time;
    public bool all_checkpoints_true = false;
    public UnityEngine.UI.Text lap_time_ui;
    public Dictionary<GameObject, bool> checkpoint_list = new Dictionary<GameObject, bool>();
    public Transform checkpoint_list_raw;
    
    
    void Start()
    {
        foreach(Transform checkpoint in checkpoint_list_raw)
        {
            checkpoint_list.Add(checkpoint.gameObject, false);
        }

    }
   

    // Update is called once per frame
    void Update()
    {
        if (start_timer)
        {
            lap_time = lap_time + Time.deltaTime;
            lap_time_ui.text = lap_time.ToString("F2");
        }
        
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Start_finish"&& start_timer == false)
        {
            start_timer = true;
        }
        else if(other.gameObject.name == "Start_finish" && start_timer == true && all_checkpoints_true==true)
        {
            start_timer = false;
        }
        
        if(checkpoint_list.ContainsKey(other.gameObject))
        {
            checkpoint_list[other.gameObject] = true;
            all_checkpoints_true = check_if_all_ckeckpoints_true();
        }

    }
    public bool check_if_all_ckeckpoints_true()
    {
        bool ret_val = true;
        foreach(KeyValuePair<GameObject,bool> checkpoint in checkpoint_list)
        {
            if (checkpoint.Value == false)
            {
                ret_val = false;
            }
        }
        return ret_val;
    }
}
