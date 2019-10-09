using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public const float UseInternalLastY = float.NaN;
    
    [SerializeField]
    protected float _minimumDeltaY;

    [SerializeField]
    private float _upperGenerationBorder;
    [SerializeField]
    private float _lowerGenerationBorder;

    [SerializeField]
    private ObjectPool[] _pool;
    protected ActiveObjectsTracker _tracker;
    private HorizontalParameters _spawnedObjectsHorizontalParameters;

    private   float _spawnZ;
    protected float _spawnX;
    protected float _lastY;
    protected GameObject _lastObject;

    
    void Start ()
    {
        InitializeFields();
    }

    protected void InitializeFields ()
    {
        _spawnX = this.transform.position.x;
        _spawnZ = this.transform.position.z;
        _spawnedObjectsHorizontalParameters = this.GetComponent<HorizontalParameters>();
        _tracker = FindObjectOfType<ActiveObjectsTracker>();
    }
    
    
    public void Spawn (ref float lastObjectY, ref float minimumDeltaY)
    {
        minimumDeltaY = _minimumDeltaY;
        lastObjectY = Spawn(lastObjectY, minimumDeltaY);
    }

    public float Spawn(float lastObjectY, float minimumDeltaY)
    {
        if (lastObjectY.Equals(UseInternalLastY))
            lastObjectY = _lastY;

        float newY = getNewPositionY(lastObjectY, minimumDeltaY);

        Spawn(newY);
        return newY;
    }

    protected virtual void Spawn(float y)
    {
        int poolNumber = Random.Range(0, _pool.Length);
        GameObject objectToSpawn = _pool[poolNumber].GetObject();

        objectToSpawn.transform.position = new Vector3(_spawnX, y, _spawnZ);
        objectToSpawn.SetActive(true);

        _tracker.AddObject(objectToSpawn);
        
        SpawnableHorizontalParameters objParams = objectToSpawn.GetComponent<SpawnableHorizontalParameters>();
        objParams.SetUpHorizontalParameters (_spawnedObjectsHorizontalParameters.VelocityX,
                                             _spawnedObjectsHorizontalParameters.AccelerationX,
                                             _spawnedObjectsHorizontalParameters.SpeedUpAcceleration);
        Debug.Log("Velocity: " + objParams.VelocityX);

        _lastObject = objectToSpawn;
    }
    

    protected float getNewPositionY(float lastObjectY, float minimumDeltaY)
    {
        float positionY;
        float deltaY;

        do
        {
            positionY = Random.Range(_lowerGenerationBorder, _upperGenerationBorder);
            deltaY = positionY - lastObjectY;
        }
        while (-minimumDeltaY < deltaY && deltaY < minimumDeltaY);

        return positionY;
    }
}
 