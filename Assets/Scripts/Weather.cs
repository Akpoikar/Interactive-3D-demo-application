using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MainSeciton
{
    public string main;
}

[System.Serializable]
public class Weather 
{
    public MainSeciton[] weather;

    public static Weather CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<Weather>(jsonString);
    }
}
