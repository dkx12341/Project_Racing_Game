using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Pad_behaviour : MonoBehaviour
{
   

    private void OnTriggerEnter(Collider other)
    {
        apply_pad_power(other);
    }

    abstract public void apply_pad_power(Collider other);
   
}
