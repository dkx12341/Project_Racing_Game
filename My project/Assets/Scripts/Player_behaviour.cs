using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_behaviour : MonoBehaviour
{

    //private GameObject player_car = (GameObject)Resources.Load("Prefabs/Car2", typeof(GameObject));
    public GameObject player_car;
    // Start is called before the first frame update
    void OnEnable()
    {
        Instantiate(player_car, gameObject.transform, worldPositionStays: false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
