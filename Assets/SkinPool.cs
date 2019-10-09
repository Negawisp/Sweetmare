using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinPool : MonoBehaviour {

    [SerializeField]
    private Skin[] _skin;

	public RuntimeAnimatorController GetAnimator (CostumeType type)
    {
        Debug.Log("We have " + _skin.Length + " skins");
        Debug.Log("Looking for type " + type);
        for (int i = 0; i < _skin.Length; i++)
        {
            Debug.Log ("Skin" + i + " type is " + _skin[i].type());
            if (_skin[i].type() == type)
                return _skin[i].animator();
        }

        return null;
    }
}
