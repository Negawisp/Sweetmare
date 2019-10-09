using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//For now it's singletone and is found in each ObjectSpawner through FindObjectOfType<>();
public class ActiveObjectsTracker : MonoBehaviour {
    
    [SerializeField]
    private int _maximumActiveObjects;
    [SerializeField]
    private GameObject[] _objPool;
    [SerializeField]
    private HorizontalParameters[] _horizontalParamsPool;
    
	void Start () {
        if (_maximumActiveObjects < 1)
            Debug.LogError("Can't spawn enemies or powerups.");

        _objPool = new GameObject[_maximumActiveObjects];
        _horizontalParamsPool = new HorizontalParameters[_maximumActiveObjects];
        for (int i = 0; i < _maximumActiveObjects; i++)
        {
            _objPool[i] = null;
            _horizontalParamsPool[i] = null;
        }
	}
	

    public void RemoveObjectAt(int index)
    {
        _objPool[index] = null;
        _horizontalParamsPool[index] = null;
    }

    public GameObject AddObject(GameObject obj)
    {
        int k = 0;
        for (k = 0; k < _maximumActiveObjects; k++) {
            if (_objPool[k] == null)
                break;
        }

        if (k == _maximumActiveObjects)
            return null;
        else
        {
            TrackingInfo _deactivationParameters = obj.GetComponent<TrackingInfo>();
            _deactivationParameters.AddObjectToTracker(k);
            _horizontalParamsPool[k] = obj.GetComponent<HorizontalParameters>();
            return _objPool[k] = obj;
        }
    }

    public void AccelerateObjects()
    {
        foreach (HorizontalParameters parameters in _horizontalParamsPool)
        {
            if (parameters) parameters.Accelerate();
        }
    }

    public void RemoveAccelerationOnObjects()
    {
        foreach (HorizontalParameters parameters in _horizontalParamsPool)
        {
            if (parameters) parameters.RemoveAcceleration();
        }
    }

    public void DecelerateObjects()
    {
        foreach (HorizontalParameters parameters in _horizontalParamsPool)
        {
            if (parameters) parameters.Decelerate();
        }
    }

    public void RestoreObjectsVelocity()
    {
        foreach (HorizontalParameters parameters in _horizontalParamsPool)
        {
            if (parameters) parameters.RestoreParameters();
        }
    }


    public void KillEachActiveObstacle()
    {
        foreach (GameObject obj in _objPool)
        {
            if (obj)
            {
                if (obj.tag.Equals("GhostShell"))
                    obj.GetComponentInChildren<ObjectCollisions>().HitPlayer();
            }
        }
    }

}
