using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Location
{
    public string geoplugin_city;
    public string geoplugin_latitude;
    public string geoplugin_longitude;

    public static Location CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<Location>(jsonString);
    }
}
