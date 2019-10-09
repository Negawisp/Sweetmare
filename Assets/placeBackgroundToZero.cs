using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeBackgroundToZero : MonoBehaviour {

    [SerializeField]
    private bg_behaviour[] _backgrounds;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RevindBackgrounds (float offset)
    {
        foreach (bg_behaviour bg in _backgrounds)
        {
            bg.Revind(offset);
        }
    }
}
