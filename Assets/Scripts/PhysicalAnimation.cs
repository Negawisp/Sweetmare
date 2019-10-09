using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalAnimation : MonoBehaviour {


    [SerializeField]
    private bool _defaultRotationSettings;
    [SerializeField]
    private float _rotationSpeed;
    [SerializeField]
    private float _rotationAmplitude;
    private float _deltaAngle;
    

    [SerializeField]
    private bool _defaultVerticalSettings;
    [SerializeField]
    private float _verticalAmplitude;
    [SerializeField]
    private float _verticalFrequency;
    private float _angle;
    private float _verticalVelocity;

    const float DefaultAmplitude = 0.28f;
    const float DefaultFrequency = 6;
    

    // Use this for initialization
    void Start () {

        if (_defaultVerticalSettings)
            SetDefaultVerticalSettings();

        if (_defaultRotationSettings)
            SetDefaultRotationSettings();
    }
	

    void FixedUpdate ()
    {
        _angle += _verticalFrequency * Time.deltaTime;
        _verticalVelocity = _verticalAmplitude * _verticalFrequency * Mathf.Cos(_angle);

        _deltaAngle += _rotationSpeed * Time.deltaTime;
        if (Mathf.Abs(_deltaAngle) >= _rotationAmplitude)
            _rotationSpeed = _rotationSpeed * (-1);

        transform.rotation = Quaternion.Euler(0, 0, _deltaAngle);
        transform.position  += new Vector3(0, _verticalVelocity * Time.fixedDeltaTime, 0);
    }


    private void SetDefaultRotationSettings()
    {
        _deltaAngle = 0;
        _rotationAmplitude = 18;
        _rotationSpeed = 100;
    }


    void SetDefaultVerticalSettings()
    {
        _verticalAmplitude = DefaultAmplitude;
        _verticalFrequency = DefaultFrequency;
    }
}
