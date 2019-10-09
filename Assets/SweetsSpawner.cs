using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweetsSpawner : ObjectSpawner {

    [SerializeField]
    private int _sweetsInARow;
    private const int _defaultSweetsInARow = 2;
    [SerializeField]
    private float _sweetsInterval;

	// Use this for initialization
	void Start () {
        InitializeFields();
        if (_sweetsInARow < 1)
            _sweetsInARow = _defaultSweetsInARow;
	}

    protected override void Spawn(float y)
    {
        for (int i = 0; i < _sweetsInARow; i++)
        {
            base.Spawn(y);
            _spawnX += _sweetsInterval;
        }
        _spawnX = this.transform.position.x;
    }
}
