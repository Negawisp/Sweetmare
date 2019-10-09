using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skin : MonoBehaviour {
    
    [SerializeField]
    private RuntimeAnimatorController _animator;
    public RuntimeAnimatorController animator() { return _animator; }

    [SerializeField]
    private CostumeType _type;
    public CostumeType type() { return _type; }
}
