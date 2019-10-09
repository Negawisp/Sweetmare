using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownsGenerator : ObjectSpawner {

    [SerializeField]
    Animator _mainGhostAnimator;
    

    

    protected override void Spawn(float y)
    {
        base.Spawn(y);
        //AnimateGhost ();
    }

    private void AnimateGhost()
    {
        float halfOfClownHeight = 5 / 2;
        float trueCenterPosition = getInsideObjectPosition(_lastObject);

        if (1.4 >= trueCenterPosition - halfOfClownHeight && trueCenterPosition > 0)
            _mainGhostAnimator.SetTrigger("GoToBottom");
        if (-1.4 <= trueCenterPosition + halfOfClownHeight && trueCenterPosition <= 0)
            _mainGhostAnimator.SetTrigger("GoToTop");

    }

    private static float getInsideObjectPosition(GameObject lastObject)
    {
        Transform[] transforms = lastObject.GetComponentsInChildren<Transform>();
        if (transforms.Length != 2)
            Debug.LogError("This class requires all pooled objects to consist of shell and its single child.");
        return transforms[1].position.y; 
    }
}
