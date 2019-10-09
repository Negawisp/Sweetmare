using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg_looper : MonoBehaviour {

    public  bg_image[]   bg_Image;
    

    int bg_sky_size_multiplier = 1;
    int number_of_bg_skyes = 2;     // Current sollution is optimal for never changing bg. 
                                    // We'll have to overthink the backgrounds if we want to have multiple locations!
                                    // Now everything is very costylful if you ask me, but I am too lazy to think well now.


    void OnTriggerEnter2D (Collider2D victim) {
        //Debug.Log ("bg_looper collided w\\ " + victim.name );

        float bg_item_width = ((BoxCollider2D)victim).size.x;

        Vector3 pos = victim.transform.position;
        //Debug.Log("Z of bg is " + pos.z);
        pos.x += bg_item_width * number_of_bg_skyes * bg_sky_size_multiplier;
        victim.transform.position = pos;
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}    
}