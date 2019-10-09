using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerHorizontalParameters : HorizontalParameters {

    void Start()
    {
        initiateParameters();
    }

    void FixedUpdate()
    {
        UpdateParameters();
    }
}
