using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bg_behaviour : MonoBehaviour {
    
    public Bg_location[] locations;
    int number_of_locations;

    public int untill_next_location;
    int location_changed;

    int cur_location_number;
    Bg_location current_location;

    [SerializeField]
    private bg_looper  looper;
    public bg_image[] bg_Image;

    public Vector3 Initial_speed;
           Vector3 speed;
    public Vector3 Initial_acceleration;
           Vector3 acceleration;


	// Use this for initialization
	protected void Start () {
        find_objects();

        speed = Initial_speed;
        acceleration = Initial_acceleration;
	}
    

    // Update is called once per frame
    void Update()
    {

    }


    protected void FixedUpdate ()
    {
        if (untill_next_location == 0)
        {
            //Debug.Log("Finally here.");
            change_location(get_next_location_number());
            //Debug.Log("" + untill_next_location + " untill next location.");
        }

        speed += acceleration * Time.deltaTime;
        transform.position += speed * Time.deltaTime;


    }

    void change_location (int location_number)
    {
        Debug.Log ("Trying to change location to " + location_number + "...");

        bg_image current_img     = get_current_img();
        bg_image last_looped_img = get_last_looped();

        last_looped_img.Change_Sprite   (current_location._transitional_sprites[location_number]);
        last_looped_img.Set_next_sprite (locations[location_number]._main_bg);

        current_img.Set_next_sprite     (locations[location_number]._main_bg);

        cur_location_number = location_number;
        current_location    = locations[location_number];

        untill_next_location = current_location._n_slides;
    }


    int get_next_location_number ()
    {
        Debug.Log ("Getting new location number...");
        int next_location_number;
        do
            next_location_number = Random.Range(0, number_of_locations);
        while (next_location_number == cur_location_number);

        Debug.Log ("Next location set (location " + next_location_number + ").");
        return next_location_number;
    }

    

    private void find_objects ()
    {
    }

    public void decr_untill_next_location ()
    {
        untill_next_location--;
    }

    bg_image get_current_img ()
    {
        if (bg_Image[0].First) return bg_Image[0];
        if (bg_Image[1].First) return bg_Image[1];
        Debug.LogError("Couldn't find out which bg is now first!");
        return bg_Image[0];
    }

    bg_image get_last_looped ()
    {
        if (bg_Image[0].First) return bg_Image[1];
        if (bg_Image[1].First) return bg_Image[0];
        Debug.LogError("Couldn't find out which bg is now last!");
        return bg_Image[0];
    }
    
    public void Revind (float offset)
    {
        Vector3 position;
        foreach (bg_image image in bg_Image)
        {
            position = image.transform.position;
            position.x -= offset;
            image.transform.position = position;
        }
    }
}
