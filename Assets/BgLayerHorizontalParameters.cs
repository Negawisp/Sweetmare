using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLayerHorizontalParameters : HorizontalParameters {

    [SerializeField]
    private GameObject[] _bgImage;

	void Start () {

        initiateParameters();
    }

    public override void UpdateParameters()
    {
        base.UpdateParameters();
        foreach (GameObject bgImage in _bgImage)
        {
            bgImage.transform.position += new Vector3(VelocityX * Time.fixedDeltaTime, 0, 0);
        }
    }

    void FixedUpdate()
    {
        UpdateParameters();
    }
    
}
