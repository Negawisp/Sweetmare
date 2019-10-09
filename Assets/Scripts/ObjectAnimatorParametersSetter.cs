using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAnimatorParametersSetter : AnimatorParameterSetter {
    

    void Start ()
    {
        _animator = GetComponent<Animator>();
    }

    public void HitPlayer()
    {
        _animator.SetTrigger("Hit");
    }
}
