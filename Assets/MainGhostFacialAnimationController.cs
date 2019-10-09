using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGhostFacialAnimationController : AnimatorParameterSetter {

    [SerializeField]
    float _tauntFrequence;
    float _lastCheckTime;


    private void FixedUpdate()
    {
        if (Time.time - _lastCheckTime > 1)
        {
            _lastCheckTime = Time.time;
            if (Random.Range(0f, 1f) < _tauntFrequence)
            {
                if (Random.Range(0f, 1f) < 0.65)
                    ShowTongue();
                else
                    ShowTeeth();
            }
        }
    }

    public void ShowTeeth()
    {
        SetTrigger("ShowTeeth");
    }

    public void ShowTongue()
    {
        SetTrigger("ShowTongue");
    }

    public void GetHit()
    {
        SetTrigger("GetHit");
        SetTrigger("ShowTeeth");
    }
}
