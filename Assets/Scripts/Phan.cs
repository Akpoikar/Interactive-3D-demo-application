using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phan : MonoBehaviour
{
    [SerializeField] GameObject _impeller;
    [SerializeField] GameObject _airflow;
    [SerializeField] bool _isWorking = false;

    [SerializeField] float _maxSpeed;
    [SerializeField] float _speedMultipliyer;

    [SerializeField] float _currSpeed;
    
    float _sliderSpeed;
    
    void Update()
    {
        Work();

        if (!_isWorking)
        {
            SliderRotate();
        }
    }
    
    /* If the object suppose to start spinning, then it will 
    rotate blades with y axies depending on the speed */
    void Work() {
        if (_isWorking == true)
        {
            if (_currSpeed <= _maxSpeed)
            {
                _impeller.transform.Rotate(0, _currSpeed, 0);
                _currSpeed += _speedMultipliyer;
            }
            else
            {
                _impeller.transform.Rotate(0, _currSpeed, 0);
            }
            _airflow.transform.localScale = new Vector3(1, 1, _currSpeed / 10);
        }
        else
        {
            if (_currSpeed > 0)
            {
                _impeller.transform.Rotate(0, _currSpeed, 0);
                _currSpeed -= _speedMultipliyer * 3;
                _airflow.transform.localScale = new Vector3(1,1, _currSpeed / 10);
            } else
            {
                _airflow.transform.localScale = new Vector3(0, 0, 0);
            }
        }
    }

    // Stop spinning animation
    public void TurnOff()
    {
        _isWorking = false;
    }
        
    // Start spinning animation
    public void TurnOn()
    {
        _isWorking = true;
    }
    
    // Rotate the object ( called by slider )
    public void ManualRotate(float num)
    {
        if (Mathf.Abs(num) < .25)
        {
            _sliderSpeed = 0;
            return;
        }
            
        _sliderSpeed = 1f * num;
        
        _impeller.transform.Rotate(0, _sliderSpeed, 0);

    }   
    
    public void SliderRotate()
    {
        _impeller.transform.Rotate(0, _sliderSpeed, 0);

    }

}
