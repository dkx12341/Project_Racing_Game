using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_controller : MonoBehaviour
{

    private GameObject car;
    private Rigidbody PlayerRB;
    private GameObject player;
    public float cam_speed;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        Waiter.Wait(1, () =>{});
        player = GameObject.FindWithTag("Player");
        while (car == null)
        {
            car = GameObject.FindWithTag("Car");
        }
        PlayerRB = car.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, car.transform.position + car.transform.TransformVector(offset), cam_speed * Time.deltaTime);
        gameObject.transform.LookAt(car.transform);
    }
}
