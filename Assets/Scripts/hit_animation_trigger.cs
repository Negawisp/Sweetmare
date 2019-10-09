using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit_animation_trigger : MonoBehaviour {

    Animator sweet_animator;

	// Use this for initialization
	void Start () {
        sweet_animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter2D()
    {
        sweet_animator.SetTrigger("Hit");
    }
}
