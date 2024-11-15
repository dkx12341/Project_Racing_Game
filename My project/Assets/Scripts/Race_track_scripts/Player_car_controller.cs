using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Timeline.Actions;
using UnityEngine;
using TMPro;
using System;


public class Player_car_controller : MonoBehaviour
{
    
    private Rigidbody player_RB;
    public WheelColliders colliders;
    public WheelMeshes wheel_meshes;
    //public SmokeGenerators wheels_smoke;
    public ParticleSystem[] smoke_generators_list;
    public GearState gear_state;

    public float gas_input;
    public float turn_input;
    public float brake_input;
    public float engine_power;
    public float brake_power;

    public float speed;
    public float wheel_speed;
    public float max_speed;
    public float slip_angle;
    public float slip_allowance = 0.3f;
    public AnimationCurve steering_curve;
    public int is_engine_running;

    public float RPM;
    public float RPM_redline;
    public float idle_RPM;
    private float wheel_RPM;
    public TMP_Text RPM_txt;
    public TMP_Text gear_txt;
    public AnimationCurve horsepower_curve;

    public float [] gear_ratios;
    public int current_gear;
    public float differential_ratio;
    private float current_troque;

    // Start is called before the first frame update
    void Start()
    {
        player_RB = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        wheel_speed = Mathf.Min(Mathf.Abs(colliders.BL_C.rpm * colliders.BL_C.radius * 2f * Mathf.PI), Mathf.Abs( colliders.BR_C.rpm * colliders.BR_C.radius * 2f * Mathf.PI)) / 10f;
        speed = Vector3.Magnitude(player_RB.velocity);
        update_wheels();
        get_input();
        apply_engine_power();
        apply_brakes();
        apply_steering();
        check_if_car_flipped();
        start_smoke();
    }
    public float Get_engine_usage()
    {
        var gas = Mathf.Clamp(gas_input, 0.5f, 1f); 
        return (Mathf.Abs(wheel_speed) * gas) / max_speed;
    }

    void apply_steering()
    {
        float turn_angle = turn_input * steering_curve.Evaluate(speed);
        colliders.FR_C.steerAngle = turn_angle;
        colliders.FL_C.steerAngle = turn_angle;
    }

    void apply_brakes()
    {
        colliders.FR_C.brakeTorque = brake_input * brake_power * 0.3f; ;
        colliders.FL_C.brakeTorque = brake_input * brake_power * 0.3f; ;
        colliders.BR_C.brakeTorque = brake_input * brake_power *0.7f;
        colliders.BL_C.brakeTorque = brake_input * brake_power *0.7f;
    }

    void apply_engine_power()
    {
       
        
        colliders.BL_C.motorTorque = engine_power * gas_input;
        colliders.BR_C.motorTorque = engine_power * gas_input;
      

    }

    void get_input()
    {
        gas_input = Input.GetAxis("Vertical");
        turn_input = Input.GetAxis("Horizontal");
        slip_angle = UnityEngine.Vector3.Angle(transform.forward, player_RB.velocity);
        if (slip_angle<120)
        {
            if (gas_input<0)
            {
                brake_input = Mathf.Abs( gas_input);
                gas_input = 0;
            }
            else
            {
                brake_input = 0;
            }
        }
        else 
        {
            if (gas_input > 0)
            {
                brake_input = Mathf.Abs(gas_input);
                gas_input = 0;
            }
            else
            {
                brake_input = 0;
            }
        }

    }

    void update_wheels()
    {
        spin_wheel(colliders.FR_C, wheel_meshes.FR_M);
        spin_wheel(colliders.FL_C, wheel_meshes.FL_M);
        spin_wheel(colliders.BR_C, wheel_meshes.BR_M);
        spin_wheel(colliders.BL_C, wheel_meshes.BL_M);
    }

    void spin_wheel(WheelCollider coll, MeshRenderer mesh)
    {
        UnityEngine.Quaternion quat;
        UnityEngine.Vector3 position;
        coll.GetWorldPose(out position, out quat);
        mesh.transform.position = position;
        mesh.transform.rotation = quat;

    }

    void check_if_car_flipped()
    {
        if(gameObject.transform.rotation.z>0.69|| gameObject.transform.rotation.z < -0.69 || gameObject.transform.rotation.x > 0.90 || gameObject.transform.rotation.x < -0.90)
        {
            if (gameObject.GetComponent<Rigidbody>().velocity.magnitude < 0.1)
            {
                
                rotate_car();
            }
        }
    }

    void rotate_car()
    {
        transform.position = transform.position + new UnityEngine.Vector3(0, 2, 0);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void start_smoke()
    {
        WheelHit hit;
        WheelCollider[] colliders_list = { colliders.FL_C, colliders.FR_C, colliders.BR_C, colliders.BL_C };
        //ParticleSystem[] smoke_generators_list = { wheels_smoke.FL_PS, wheels_smoke.FR_PS, wheels_smoke.BR_PS, wheels_smoke.BL_PS };
        for(int i = 0; i < colliders_list.Length; i++ )
        {
            if (colliders_list[i].GetGroundHit(out hit))
            {
                if(Mathf.Abs(hit.forwardSlip)+ Mathf.Abs(hit.sidewaysSlip)>= slip_allowance)
                {
                    if (!smoke_generators_list[i].isPlaying)
                    {
                        smoke_generators_list[i].Play();
                    }
                }
                else
                {
                    if (smoke_generators_list[i].isPlaying)
                    {
                        smoke_generators_list[i].Stop() ;
                    }
                }
            }
        }
    }
}

[System.Serializable]
public struct WheelColliders
{
    public WheelCollider FR_C;
    public WheelCollider FL_C;
    public WheelCollider BR_C;
    public WheelCollider BL_C;
}
[System.Serializable]
public struct WheelMeshes
{
    public MeshRenderer FR_M;
    public MeshRenderer FL_M;
    public MeshRenderer BR_M;
    public MeshRenderer BL_M;
}

[System.Serializable]
public struct SmokeGenerators
{
    public ParticleSystem FR_PS;
    public ParticleSystem FL_PS;
    public ParticleSystem BR_PS;
    public ParticleSystem BL_PS;
}

public enum GearState
{
    neutral,
    running,
    checking_change,
    changing
}