using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_controller : MonoBehaviour
{
    public Transform player;
    private Rigidbody PlayerRB;
    public float cam_speed;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.position + player.transform.TransformVector(offset), cam_speed * Time.deltaTime);
        transform.LookAt(player);
    }
}
