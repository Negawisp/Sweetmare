using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HommingProjectile : MonoBehaviour {

    [SerializeField]
    private MainGhostSpawner _ghost;

    [SerializeField]
    private bool _launched;
    [SerializeField]
    private SpawnableHorizontalParameters _horizParams;

    [SerializeField]
    private Vector3 _velocity;
    [SerializeField]
    private float   _velocityScale;
    [SerializeField]
    private float   _angularV;
    private float   _angle;

    [SerializeField]
    private Transform _transform;

	// Use this for initialization
	void Start () {

        _ghost = FindObjectOfType<MainGhostSpawner>();
        _launched = false;
        _angle = 0;

        if (_angularV < 1 && _velocityScale < 1)
        {
            _angularV = -2000;
            _velocityScale = 20;
        }

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (_launched)
        {
            _transform.position += _velocity * Time.deltaTime;
            _angle += _angularV * Time.deltaTime;
            _transform.rotation = Quaternion.Euler(0, 0, _angle);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Invincible"))
        {
            Launch();
        }
    }


    public void Launch ()
    {
        _horizParams.Stop();

        _launched = true;
        Vector3 deltaR = _ghost.GetPosition() - _transform.position;
        _velocity = _velocityScale * deltaR.normalized;        
    }

    public void Launch(float velocityScale) {

        _velocityScale = velocityScale;
        Launch();
    }
    

    public void Reset()
    {
        Debug.Log("Actually resetting!");
        _launched = false;
    }
}
