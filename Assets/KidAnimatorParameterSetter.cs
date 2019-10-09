using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidAnimatorParameterSetter : AnimatorParameterSetter {

    public void SetRemainingSpeedUpTime(int timeRemaining)
    {
        Debug.Log("Trying to Set Remaining SpeedUp time...");
        _animator.SetInteger("SpeedUpTimeRemaining", timeRemaining);
    }

    public void GetHit(int remainingHealth)
    {
        _animator.SetTrigger("LoseLife" + remainingHealth);
    }

    public void PickUpSweet()
    {
        _animator.SetTrigger("SweetPickUp");
    }

    public void PickUpBoost(BoostType _boostType)
    {
        if (_boostType == BoostType.any)
            _boostType = BoostType.lollipop;
        
        //Comparing with integer constants because they are in names of triggers.
        if ((int)_boostType == 0 || (int)_boostType == 1)
            _animator.SetTrigger("BoostPickUp" + (int)_boostType);
        else
            Debug.LogWarning("Pick up Animation of boost type with nuber " + (int)_boostType + "\" is not defined.");
    }

    public void LaunchInvincibility()
    {
        _animator.SetTrigger("BecameInvinsible");
    }

    public void Revive()
    {
        _animator.SetTrigger("Revive");
    }
}
