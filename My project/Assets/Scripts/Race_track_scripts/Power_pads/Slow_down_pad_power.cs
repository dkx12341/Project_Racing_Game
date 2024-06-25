using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow_down_pad_power : Pad_power
{
    public float slow_down_power = -20000f;
    // Start is called before the first frame update
    public override void apply_pad_power(Collider other)
    {
        Rigidbody player_RB = other.gameObject.GetComponent<Rigidbody>();

        player_RB.AddForce(other.gameObject.transform.forward * slow_down_power, ForceMode.Impulse);
    }
}
