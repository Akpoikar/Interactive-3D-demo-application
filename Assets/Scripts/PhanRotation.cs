using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhanRotation : MonoBehaviour
{
    [SerializeField] Joystick _joystick;

    [SerializeField] float _turnSpeed = 1f;

    Vector3 _defaultRotation;

    void Start()
    {
        _defaultRotation = transform.rotation.eulerAngles;
    }

    // Reset rotattion to default values
    public void ResetRotation()
    {
        transform.rotation = Quaternion.Euler( _defaultRotation);
    }

    void FixedUpdate()
    {
        // Rotate the object related to the joystick axes
        Rotate();
    }

    private void Rotate()
    {
        transform.rotation = transform.rotation
            * Quaternion.AngleAxis(_joystick.Horizontal * _turnSpeed, Vector3.forward);

        transform.rotation = transform.rotation
            * Quaternion.AngleAxis(_joystick.Vertical * _turnSpeed, -Vector3.right);
    }
}
