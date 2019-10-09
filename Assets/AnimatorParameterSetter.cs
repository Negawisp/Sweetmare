using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorParameterSetter : MonoBehaviour {


    [SerializeField]
    protected Animator _animator;
    [SerializeField]
    private string _parameterName;

    [SerializeField]
    private float _floatInitialValue;
    [SerializeField]
    private int _intInitialValue;
    [SerializeField]
    private bool _boolInitialValue;
    

    public void SetTrigger()
    {
        _animator.SetTrigger(_parameterName);
    }

    public void SetTrigger(string triggerName)
    {
        _animator.SetTrigger(triggerName);
    }

    public void SetBool()
    {
        _animator.SetBool(_parameterName, _boolInitialValue);
    }

    public void SetInt()
    {
        _animator.SetInteger(_parameterName, _intInitialValue);
    }

    public void SetFloat()
    {
        _animator.SetFloat(_parameterName, _floatInitialValue);
    }



    public void SetParameter(string parameterName)
    {
        _animator.SetTrigger(parameterName);
    }

    public void SetParameter(string parameterName, bool value)
    {
        _animator.SetBool(parameterName, value);
    }

    public void SetParameter(string parameterName, int value)
    {
        _animator.SetInteger(parameterName, value);
    }

    public void SetParameter(string parameterName, float value)
    {
        _animator.SetFloat(parameterName, value);
    }


}
