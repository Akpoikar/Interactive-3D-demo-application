using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherEffects : MonoBehaviour
{
    readonly List<GameObject> effects = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            effects.Add(transform.GetChild(i).gameObject);
        }
        WeatherBehavior.WeatherFound += WeatherBehavior__weatherFound;
    }

    // Once weather is found, set the corresponding gameobject to active
    private void WeatherBehavior__weatherFound()
    {
        WeatherBehavior weathear = FindObjectOfType<WeatherBehavior>();

        for (int i = 0; i < effects.Count; i++)
        {
            if(effects[i].name.Equals(weathear.GetCurrWeather()))
            {
                effects[i].SetActive(true);
                break;
            }
        }
   
    }
}
