using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliter_trigger : MonoBehaviour
{
    public Race_controller race_controller;
    void Start()
    {
       race_controller = GameObject.FindWithTag("Race_controller").GetComponent<Race_controller>();
    }
        void OnTriggerEnter(Collider other)
    {
        race_controller.Detect_collision = other;        
    }

}
