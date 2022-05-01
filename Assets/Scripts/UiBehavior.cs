using UnityEngine;
using TMPro;

public class UiBehavior : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _location;
    [SerializeField] TextMeshProUGUI _currWeather;

    public void SetLocation(string location)
    {
        _location.text = location;
    }

    private void Start()
    {
        _location.text = "Waiting for the info...";
        _currWeather.text = "";
        WeatherBehavior.WeatherFound += WeatherBehavior__weatherFound;
    }

    
    private void WeatherBehavior__weatherFound()
    {
        WeatherBehavior weathear = FindObjectOfType<WeatherBehavior>();
        _location.text = "Currently, you are in " + weathear.GetCurrCity();
        _currWeather.text = weathear.GetCurrWeather();
    }


}
