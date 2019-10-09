using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinLoader : MonoBehaviour {


    [SerializeField]
    private SkinPool _skinPool;
    [SerializeField]
    private Animator _animator;


	void Awake () {
        CostumeType type = (CostumeType)PlayerPrefs.GetInt("FullBodySkin");
        Debug.Log("Saved skin is " + type + ", Default is " + CostumeType.Default);

        RuntimeAnimatorController anim = _skinPool.GetAnimator(type);
        if (anim == null)
            Debug.LogError("_skinPool.GetAnimator(type) RETURNED NULL!");
        _animator.runtimeAnimatorController = anim;
    }
}
