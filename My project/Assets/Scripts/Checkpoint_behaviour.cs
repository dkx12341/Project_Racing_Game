using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint_behaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
    


}
