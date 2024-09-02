using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Car_selection_controller : MonoBehaviour
{

    public UnityEngine.Object[] cars_list;

    public GameObject Garage;


    public SO_string Selected_car;

    private int currently_viewed_track_num = 0;

    public GameObject currently_displayed_car;

    public TMP_Text car_name;

    // Start is called before the first frame update
    void Start()
    {
        Get_cars_list();

        currently_displayed_car = (GameObject) Instantiate(cars_list[currently_viewed_track_num], Garage.transform);
        car_name.text = cars_list[currently_viewed_track_num].name;

    }

    // Update is called once per frame
    void Update()
    {
        



    }

    void Get_cars_list()
    {
        List<string> cars = new List<string>();
        cars_list = Resources.LoadAll("Prefabs/Car_models");

        for (int i = 0; cars_list.Length > i; i++)
        {
            cars.Add(cars_list[i].name);
        }
    }

    public void On_left_button()
    {
        if( currently_viewed_track_num != 0 )
        {
            currently_viewed_track_num = currently_viewed_track_num - 1;
        }
        else
        {
            currently_viewed_track_num = cars_list.Length-1;
        }

        Destroy(currently_displayed_car);
        currently_displayed_car = (GameObject)Instantiate(cars_list[currently_viewed_track_num], Garage.transform);
        car_name.text = cars_list[currently_viewed_track_num].name;
    }

    public void On_right_button()
    {
        if (currently_viewed_track_num != cars_list.Length - 1)
        {
            currently_viewed_track_num = currently_viewed_track_num + 1;
        }
        else
        {
            currently_viewed_track_num = 0;
        }

        Destroy(currently_displayed_car);
        currently_displayed_car = (GameObject)Instantiate(cars_list[currently_viewed_track_num], Garage.transform);
        car_name.text = cars_list[currently_viewed_track_num].name;
    }

    public void On_select_button()
    {
        Selected_car.Str = cars_list[currently_viewed_track_num].name;
    }

}
