using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class WeatherBehavior : MonoBehaviour
{
    public static event Action WeatherFound;

    string _currentIP;

    string _currCity;
    string _currWeather;

    float _currLatitude;
    float _currLongitude;

    readonly string _apiKey = "dd238ad7fc723603aa680f3d8ce5b0cd";

    public string GetCurrCity() => _currCity;
    public string GetCurrWeather() => _currWeather;

    void Start()
    {
        StartCoroutine(SendIpRequest());
    }

    // Get Ip
    IEnumerator SendIpRequest()
    {
        UnityWebRequest webRequest = UnityWebRequest.Get("api.ipify.org/?format=json");

        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError || webRequest.isHttpError)
        {
            FindObjectOfType<UiBehavior>().SetLocation("IP ERROR");
        }
        else
        {
            Ip ip = Ip.CreateFromJSON(webRequest.downloadHandler.text);
            _currentIP = ip.ip;
            StartCoroutine(SendLocationRequest());
        }
    }

    // Get latitude and longtitude depending on current Ip
    IEnumerator SendLocationRequest()
    {
        UnityWebRequest webRequest = UnityWebRequest.Get("geoplugin.net/json.gp?ip=" + _currentIP);
        yield return webRequest.SendWebRequest();

        if (webRequest.isNetworkError || webRequest.isHttpError)
        {
            FindObjectOfType<UiBehavior>().SetLocation("LOCATION ERROR");
        }
        else
        {
            Location location = Location.CreateFromJSON(webRequest.downloadHandler.text);
            _currCity = location.geoplugin_city;
            _currLatitude = float.Parse(location.geoplugin_latitude);
            _currLongitude = float.Parse(location.geoplugin_longitude);

            StartCoroutine(SendWeatherRequest());
        }
    }

    // Get weather depending on current latitude and longtitude values
    IEnumerator SendWeatherRequest()
    {
        Debug.Log(_currLatitude);
        Debug.Log(_currLongitude);
        UnityWebRequest webRequest = UnityWebRequest.Get(
            "api.openweathermap.org/data/2.5/weather?lat=" + _currLatitude.ToString()
            + "&lon=" + _currLongitude.ToString() + "&appid=" + _apiKey);

        yield return webRequest.SendWebRequest();

        if (webRequest.isNetworkError || webRequest.isHttpError)
        {
            FindObjectOfType<UiBehavior>().SetLocation("WEATHER ERROR");
        }
        else
        {

            Weather weather = Weather.CreateFromJSON(webRequest.downloadHandler.text);

            Debug.Log(weather.weather[0].main);
            _currWeather = weather.weather[0].main;

            WeatherFound?.Invoke();
        }
    }   

}
