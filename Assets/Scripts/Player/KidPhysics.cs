using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidPhysics : MonoBehaviour {

    [SerializeField]
    private float _gravityDerivative;
    [SerializeField]
    private float _initialGravity;
    [SerializeField]
    private float   _assendMultiplier;
    private float _ascendAcceleration;
    private float _gravity;

    private bool _isAscending;

    [SerializeField]
    private float _seilingY;
    [SerializeField]
    private float _floorY;
    
    [SerializeField]
    private float _faceDownYVelocity;      //Used to spin kid depending on Y velocity
    private float _velocity;
    

    void Start()
    {
        _ascendAcceleration = _assendMultiplier * _initialGravity;
        _gravity = _initialGravity;
        _velocity = 0;
    }
    
    void Update()
    {
        CheckInput();
    }

    void FixedUpdate() {

        UpdateGravity();

        if (CheckAndStopOnFloorOrSeiling())
            return;

        UpdateVelocity();
        UpdateTransform();
    }
    

    private void UpdateGravity()
    {
        _gravity += _gravityDerivative * Time.fixedDeltaTime;
    }
    
    private void UpdateVelocity()
    {
        float acceleration = _gravity;
        if (_isAscending)
        {
            acceleration += _gravity * _assendMultiplier;
        }

        _velocity += acceleration * Time.fixedDeltaTime;
    }

    private void UpdateTransform()
    {
        float angle = (_velocity / _faceDownYVelocity) * 90;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        transform.position += new Vector3(0, _velocity) * Time.fixedDeltaTime;
    }


    void CheckInput()
    {
        if (Input.GetMouseButtonDown(0) || (Input.GetKeyDown(KeyCode.Space)))
            _isAscending = true;
        if (Input.GetMouseButtonUp(0) || (Input.GetKeyUp(KeyCode.Space)))
            _isAscending = false;
    }


    bool CheckAndStopOnFloorOrSeiling()
    {
        if (HitsFloor())
        {
            _velocity = 0;
            transform.position = new Vector3(transform.position.x, _floorY, transform.position.z);
            return true;
        }

        if (HitsCeiling())
        {
            _velocity = 0;
            transform.position = new Vector3(transform.position.x, _seilingY, transform.position.z);
            return true;
        }

        return false;
    }
    
    private bool HitsCeiling()
    {
        return (transform.position.y > _seilingY) && (_velocity > 0 || _isAscending);
    }

    private bool HitsFloor()
    {
        return (transform.position.y < _floorY) && (_velocity < 0 || !_isAscending);
    }
}