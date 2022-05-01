using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xray : MonoBehaviour
{
    public GameObject[] _gameObjectsToXRay;
    public float _tranpasertValue;


    // Turn on Xray ( change material color to more transparent depending on tranpasert value )
    public void XRayOn()
    {
        for (int i = 0; i < _gameObjectsToXRay.Length; i++)
        {
            Color xraycolor = 
                _gameObjectsToXRay[i].transform.GetComponent<Renderer>().material.color ;
        
            xraycolor.a *= _tranpasertValue;


            _gameObjectsToXRay[i].transform.GetComponent<Renderer>().material.SetColor("_BaseColor", xraycolor);
        }
    }

    // Turn off Xray ( change material color full visible )
    public void XRayOff()
    {
        for (int i = 0; i < _gameObjectsToXRay.Length; i++)
        {
            Color xraycolor =
                _gameObjectsToXRay[i].transform.GetComponent<Renderer>().material.color;

            xraycolor.a = 1;


            _gameObjectsToXRay[i].transform.GetComponent<Renderer>().material.SetColor("_BaseColor", xraycolor);
        }
    }
}
