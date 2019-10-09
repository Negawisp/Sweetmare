using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGhostCollision : MonoBehaviour {

    [SerializeField]
    private GameObject _cortex;

    [SerializeField]
    private float _hitDeltaX;

    private MainGhostFacialAnimationController _anim;

	// Use this for initialization
	void Start () {
        _anim = GetComponent<MainGhostFacialAnimationController>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Projectile"))
        {
            _anim.GetHit();
            ObjectAnimatorParametersSetter _param =
                collision.gameObject.GetComponent<ObjectAnimatorParametersSetter>();
            _param.HitPlayer();
            _cortex.transform.position += new Vector3(_hitDeltaX, 0, 0);
        }
    }
}
