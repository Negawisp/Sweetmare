using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollisions : MonoBehaviour {

    private string _tagname;
    private ObjectAnimatorParametersSetter _animatorController;

    void Start ()
    {
        _tagname = gameObject.tag;
        _animatorController = GetComponent<ObjectAnimatorParametersSetter>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("GameController"))
        {
            gameObject.tag = _tagname;
        }
    }

    public void HitPlayer()
    {
        Debug.Log("Hit player");
        gameObject.tag = "Hit";
        _animatorController.HitPlayer();
    }
}
