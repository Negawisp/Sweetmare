using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingInfo : MonoBehaviour {
        
    private string _tagname;
    private int _indexInTracker;
    private ActiveObjectsTracker _tracker;
    private ObjectAnimatorParametersSetter _objectAnimatorParamSetter;


    void Start()
    {
        _tracker = FindObjectOfType<ActiveObjectsTracker>();
        _objectAnimatorParamSetter = GetComponent<ObjectAnimatorParametersSetter>();
        _tagname = gameObject.tag;
    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("GameController"))
        {
            _tracker.RemoveObjectAt(_indexInTracker);
            gameObject.tag = _tagname;
            gameObject.SetActive(false);
        }
    }

    public void AddObjectToTracker (int indexInTracker)
    {
        _indexInTracker = indexInTracker;
    }
}
