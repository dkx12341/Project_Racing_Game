     using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SO_float : ScriptableObject
{
    [SerializeField]

    private float val;

    public float Val
    {
        get { return val; }
        set { val = value; }
    }

}
