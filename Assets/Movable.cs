using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : HorizontalParameters
{
    void Start()
    {
        initiateParameters();
    }
    
    public override void UpdateParameters()
    {
        base.UpdateParameters();
        this.transform.position += new Vector3(VelocityX * Time.fixedDeltaTime, 0, 0);
    }

    void FixedUpdate()
    {
        UpdateParameters();
    }
}
