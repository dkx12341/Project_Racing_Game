using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SO_string : ScriptableObject
{
    [SerializeField]

    private string str;

    public string Str
    {
        get { return str; }
        set { str = value; }
    }

}
