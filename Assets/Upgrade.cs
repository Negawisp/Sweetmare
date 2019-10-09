using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour {
    
    protected string _name;
    public string Name
    {
        get { return _name; }
    }

    [SerializeField]
    protected int _maxLevel;
    public int MaxLevel
    {
        get { return _maxLevel; }
    }

    [SerializeField]
    protected int _level;
    public int Level
    {
        get { return _level; }
    }


    
    

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void PurchaseUpgrade()
    {

    }
}
