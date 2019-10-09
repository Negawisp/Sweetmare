using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {

    [System.Serializable]
    public struct SpawnerShell
    {
        public float Tag;
        public float PossibilityWeight;
        public ObjectSpawner Spawner;
    }

    [SerializeField]
    private float _regularSpawnPeriod;
    [SerializeField]
    private float _speedUpSpawnPeriod;
    private float _spawnPeriod;
    private float _lastSpawnTime;

    private float _lastY;
    private float _lastMinimumDeltaY;

    [SerializeField]
    private SpawnerShell[] _spawner;
    [SerializeField]
    private ObjectSpawner[] _OldSpawner;
    private float[] _possibilityIntervalEnd;
    private float   _summaryPossibilityWeight;


    public void EnableSpeedUpMode()
    {
        _spawnPeriod = _speedUpSpawnPeriod;
    }

    public void DisableSpeedUpMode()
    {
        _spawnPeriod = _regularSpawnPeriod;
    }


    void Start () {
        _spawnPeriod = _regularSpawnPeriod;
        SetUpPossibilityIntervals();
	}
	
	void FixedUpdate () {

        if (Time.time - _lastSpawnTime > _spawnPeriod)
        {
            SpawnRandomObject();
        }
    }
    

    private void SpawnRandomObject()
    {
        int spawnerNumber = RollSpawnerNumber();
        _spawner[spawnerNumber].Spawner.Spawn(ref _lastY, ref _lastMinimumDeltaY);
        _lastSpawnTime = Time.time;
    }


    private void SetUpPossibilityIntervals()
    {
        for (int i = 0; i < _spawner.Length; i++)
        {
            _spawner[i].Tag = -2;
        }

        int spawnerLength = _spawner.Length;
        _possibilityIntervalEnd = new float[spawnerLength];

        float previousIntervalEnd = 0;
        for (int i = 0; i < spawnerLength; i++)
        {
            _possibilityIntervalEnd[i] = _spawner[i].PossibilityWeight + previousIntervalEnd;
            previousIntervalEnd = _possibilityIntervalEnd[i];
        }

        _summaryPossibilityWeight = _possibilityIntervalEnd[spawnerLength - 1];
    }


    private int RollSpawnerNumber()
    {
        int spawnerLength = _spawner.Length;

        float rngValue = Random.Range(0, _summaryPossibilityWeight);

        for (int i = 0; i < spawnerLength; i++)
        {
            if (rngValue <= _possibilityIntervalEnd[i])
            {
                return i;
            }
        }

        Debug.LogError("Couldn't roll what to spawn. Rework the \"RollSpawnerNumber\"");
        return 0;
    }

    public void DecreaseTastyPossibility(int deathNumber)
    {
        Debug.Log("Death number is " + deathNumber);
        if (_spawner[2].Tag < -1)
            _spawner[2].Tag = _spawner[2].PossibilityWeight;

        if (deathNumber < 3)
        {
            float newWeight = _spawner[2].Tag * Mathf.Sqrt(1 - deathNumber / 3f);

            Debug.Log("Trying to change possibility weight to " + newWeight);
            _spawner[2].PossibilityWeight = newWeight;
        }
    }
}