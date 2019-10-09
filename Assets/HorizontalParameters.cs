using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalParameters : MonoBehaviour {

    [SerializeField]
    private float _initialAccelerationX;
    [SerializeField]
    protected float _accelerationX;
    public float AccelerationX
    {
        get { return _accelerationX; }
    }

    [SerializeField]
    private float _initialVelocityX;
    [SerializeField]
    protected float _velocityX;
    public float VelocityX
    {
        get { return _velocityX; }
    }


    [SerializeField]
    protected float _speedUpAcceleration;
    public float SpeedUpAcceleration
    {
        get { return _speedUpAcceleration; }
    }

    [SerializeField]
    private float _backUpAcceleration;
    private float _backUpVelocity;

    protected virtual void initiateParameters()
    {
        _backUpAcceleration = 0;
        _backUpVelocity = 0;
        _accelerationX = _initialAccelerationX;
        _velocityX = _initialVelocityX;
    }


    void Start()
    {
        initiateParameters();
    }

    void FixedUpdate()
    {
        UpdateParameters();
    }


    public virtual void UpdateParameters()
    {
        _velocityX += _accelerationX * Time.fixedDeltaTime;
    }


    public virtual void Accelerate()
    {
        _backUpVelocity = _velocityX;
        _backUpAcceleration = _accelerationX;

        _accelerationX = _speedUpAcceleration;
    }
    
    public virtual void RemoveAcceleration()
    {
        _accelerationX = 0;
    }

    public virtual void Decelerate()
    {
        _accelerationX = -_backUpAcceleration;
    }

    public void RestoreParameters()
    {
        Debug.Log("Restoring:\nbackUpVelocity = " + _backUpVelocity + "\nbackUpAcceleration = " + _backUpAcceleration);
        _accelerationX = _backUpAcceleration;
        _velocityX = _backUpVelocity;
    }

    public void Stop()
    {
        _accelerationX = 0;
        _velocityX = 0;
        _speedUpAcceleration = 0;
    }
}
