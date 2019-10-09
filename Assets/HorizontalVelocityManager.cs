using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalVelocityManager : MonoBehaviour {
        
    private KidAnimatorParameterSetter _animatorParamSetter;
    
    private int _speedUpDuration;
    private int _remainingSpeedUpTime;
    
    private HorizontalParameters[] _movables;
    private SpawnerController _spawnerController;
    private ActiveObjectsTracker _tracker;
    

    void Start () {
        _spawnerController = FindObjectOfType<SpawnerController>();
        _animatorParamSetter = GetComponent<KidAnimatorParameterSetter>();
        _movables = FindObjectsOfType<HorizontalParameters>();
        _tracker = FindObjectOfType<ActiveObjectsTracker>();

        _speedUpDuration = PlayerPrefs.GetInt("SpeedUpDuration");
    }

    public void DecreaseSpeedupTime()
    {
        _remainingSpeedUpTime--;
        _animatorParamSetter.SetRemainingSpeedUpTime(_remainingSpeedUpTime);
    }

    public void DecreaseSpeedUpTime()
    {
        _remainingSpeedUpTime--;
        _animatorParamSetter.SetRemainingSpeedUpTime(_remainingSpeedUpTime);
    }


    public void AllAccelerate()
    {
        _animatorParamSetter.SetRemainingSpeedUpTime(_speedUpDuration);
        _remainingSpeedUpTime = _speedUpDuration;

        _spawnerController.EnableSpeedUpMode();
        _tracker.AccelerateObjects();
        for (int i = 0; i < _movables.Length; i++)
        {
            Debug.Log("Movable number " + i + ":");
            _movables[i].Accelerate();
        }
    }


    public void AllRemoveAcceleration()
    {
        foreach (HorizontalParameters movable in _movables)
        {
            movable.RemoveAcceleration();
        }
    }

    public void AllDecelerate()
    {
        _tracker.DecelerateObjects();
        foreach (HorizontalParameters movable in _movables)
        {
            movable.Decelerate();
        }
    }

    public void AllRestoreVelocity()
    {
        _tracker.DecelerateObjects();
        _spawnerController.DisableSpeedUpMode();
        foreach (HorizontalParameters movable in _movables)
        {
            movable.RestoreParameters();
        }
    }

    

}
