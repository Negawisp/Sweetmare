using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_ghost_animation : MonoBehaviour {

    public bool     Spin_enabled;
    public float    Spin_velocity;
           float    angle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {


    }

    void FixedUpdate ()
    {
        if (Spin_enabled) Spin();
    }

    void Spin ()
    {
        angle += Spin_velocity * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
