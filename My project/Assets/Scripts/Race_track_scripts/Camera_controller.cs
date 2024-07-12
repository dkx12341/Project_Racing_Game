using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_controller : MonoBehaviour
{

    private GameObject players_car;
    private Rigidbody PlayerRB;
    private GameObject player;

    public float cam_speed;
    private Vector3 camera_offset = new Vector3(0,8,-15);


    // Start is called before the first frame update
    void Start()
    {
        Waiter.Wait(1, () =>{}); //Needs to wait for car to spawn 
        FindPlayerCar();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, players_car.transform.position + players_car.transform.TransformVector(camera_offset), cam_speed * Time.deltaTime);
        gameObject.transform.LookAt(players_car.transform);
    }

    void FindPlayerCar()
    {
        player = GameObject.FindWithTag("Player");

        while (players_car == null)
        {
            players_car = GameObject.FindWithTag("Car");
        }

        PlayerRB = players_car.GetComponent<Rigidbody>();
    }
}
