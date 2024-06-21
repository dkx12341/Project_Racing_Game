using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed_up_pad_behaviour : Pad_behaviour
{
    private void OnTriggerEnter(Collider other)
    {
        apply_pad_power(other);
    }
    public void apply_pad_power(Collider other)
    {

    }




}
