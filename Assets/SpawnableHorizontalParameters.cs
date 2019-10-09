using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableHorizontalParameters : HorizontalParameters {
    
    protected override void initiateParameters()
    {
    }

    public override void UpdateParameters()
    {
        base.UpdateParameters();
        transform.position += new Vector3 (_velocityX * Time.fixedDeltaTime, 0, 0);
    }

    public void SetUpHorizontalParameters(float velocity, float acceleration, float speedUpAcceleration)
    {
        Debug.Log("Setting up parameters... (velocity " + velocity + ").");
        _velocityX           = velocity;
        _accelerationX       = acceleration;
        _speedUpAcceleration = speedUpAcceleration;
        Debug.Log("Setting up parameters... (velocity " + _velocityX + ").");

        HommingProjectile _pr = GetComponentInChildren<HommingProjectile>();
        if (_pr != null)
        {
            Debug.Log("Trying to reset HommingProjectile");
            _pr.Reset();
        }
    }
}
