using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SO_int : ScriptableObject
{
    [SerializeField]

    private int val;
    
    public int Val
    {
        get { return val; }
        set { val = value; }
    }

}
