using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Ip
{
    public string ip;

    public static Ip CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<Ip>(jsonString);
    }
}

