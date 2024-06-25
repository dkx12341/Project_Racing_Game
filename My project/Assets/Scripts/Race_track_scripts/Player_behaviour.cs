using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player_behaviour : MonoBehaviour
{

    //private GameObject player_car = (GameObject)Resources.Load("Prefabs/Car2", typeof(GameObject));
    public SO_string Selected_car;
    // Start is called before the first frame update
    void OnEnable()
    {
        string car_name = "Prefabs/Cars/"+Selected_car.Str;
        GameObject car = (GameObject)Resources.Load(car_name,typeof(GameObject));
        Instantiate(car, gameObject.transform, worldPositionStays: false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
