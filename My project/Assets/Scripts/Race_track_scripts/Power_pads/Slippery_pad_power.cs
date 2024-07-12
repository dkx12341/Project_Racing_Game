using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slippery_pad_power : Pad_power
{
    public new float power_time = 4;
    
    public float slip_power = 2;

    // Start is called before the first frame update
    public override void apply_pad_power(Collider other)
    {
        GameObject players_car = other.gameObject;
        WheelCollider [] wheel_colliders = players_car.GetComponentsInChildren<WheelCollider>();

        divide_stiffness(wheel_colliders);


        Waiter.Wait(power_time, () =>
        {
            multiply_stiffness(wheel_colliders);

        });
    }

    private void divide_stiffness(WheelCollider[] wheel_colliders)
    {
        foreach (WheelCollider wheel in wheel_colliders)
        {
            WheelFrictionCurve friction = wheel.forwardFriction;
            friction.stiffness = (friction.stiffness / slip_power);
            wheel.forwardFriction = friction;

            friction = wheel.sidewaysFriction;
            friction.stiffness = (friction.stiffness / slip_power);
            wheel.sidewaysFriction = friction;
        }
    }

    private void multiply_stiffness(WheelCollider[] wheel_colliders)
    {

        foreach (WheelCollider wheel in wheel_colliders)
        {
            WheelFrictionCurve friction = wheel.forwardFriction;
            friction.stiffness = (friction.stiffness * slip_power);
            wheel.forwardFriction = friction;

            friction = wheel.sidewaysFriction;
            friction.stiffness = (friction.stiffness * slip_power);
            wheel.sidewaysFriction = friction;
        }
    }
}
