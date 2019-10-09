using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {
    
    [SerializeField]
    private GameObject pooledObject;

    [SerializeField]
    private int _initialPoolCount;
    private int _poolCount;
    List<GameObject> _item;
    
    void Start()
    {
        _item = new List <GameObject>();
        IncreasePool (_initialPoolCount);
    }


    private GameObject IncreasePool(int newCopiesAmmount)
    {
        GameObject newObject = null;
        for (int i = 0; i < newCopiesAmmount; i++)
        {
            newObject = Instantiate(pooledObject);
            newObject.SetActive(false);
            _item.Add(newObject);
        }
        _poolCount = _item.Count;
        return newObject;
    }


    public GameObject GetObject()
    {
        for (int i = 0; i < _poolCount; i++)
        {
            if (!_item[i].activeInHierarchy)
                return _item[i];
        }

        Debug.LogWarning("Couldn't find inactive object in list of " + _item.Count + " items.\n" +
                       "Probably initial count should be increased.");
        return IncreasePool(1);
    }
}
