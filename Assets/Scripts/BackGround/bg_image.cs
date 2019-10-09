using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg_image : MonoBehaviour {

    SpriteRenderer sprite_renderer;

    public bg_image Another_bg;
    public bg_behaviour Owner;

    public Sprite next_sprite;
    public bool row_is_empty;
    
    public bool looped; public bool get_looped() { return looped; }
    int number_of_f_updates;

    public bool First;

    void OnTriggerEnter2D()
    {
        number_of_f_updates = 3;
        looped = true;

        if (!row_is_empty)
        {
            Change_Sprite(next_sprite);
            row_is_empty = true;
        }

        First = !First;
        Another_bg.First = !Another_bg.First;
        
        transform.position            = new Vector3 (transform.position.x,
                                                     transform.position.y,
                                                     transform.position.z + 1f);
        Another_bg.transform.position = new Vector3 (Another_bg.transform.position.x,
                                                     Another_bg.transform.position.y,
                                                     Another_bg.transform.position.z - 1f);

        Owner.decr_untill_next_location();
    }
    

    // Use this for initialization
    void Start()
    {
        sprite_renderer = GetComponent<SpriteRenderer>();
        looped = false;
        number_of_f_updates = 3;
        row_is_empty = true;
    }


    void FixedUpdate()
    {
        if (looped)
        {
            number_of_f_updates--;
            if (number_of_f_updates == 0)
                looped = false;
        }
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void Set_next_sprite (Sprite next_Sprite)
    {
        next_sprite  = next_Sprite;
        row_is_empty = false;
    }

    public bool Change_Sprite(Sprite new_sprite)
    {
        sprite_renderer.sprite = new_sprite;
        return true;
    }


}
