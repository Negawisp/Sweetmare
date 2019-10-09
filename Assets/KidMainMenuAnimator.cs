using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KidMainMenuAnimator : MonoBehaviour {


    private bool _looksLeft;

    [SerializeField]
    private float _blinkPossibilityPerSecond;
    [SerializeField]
    private float _blinkPossibility;
    private float _lastTime;

    private Animator _animator;

	// Use this for initialization
	void Start () {
        _looksLeft = true;
        _animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        

    }

    void FixedUpdate()
    {
        _blinkPossibility +=  _blinkPossibilityPerSecond;
        float _randomValue = Random.Range(0f, 1f);


        if (Time.time - _lastTime >= 1)
        {
            _lastTime = Time.time;
            if (_randomValue < _blinkPossibility)
            {
                _blinkPossibility = 0;
                if (_looksLeft)
                    _animator.SetTrigger("blinkRight");
                else
                    _animator.SetTrigger("blinkLeft");
                _animator.SetTrigger("blink");

                if (Random.Range(0f, 1f) < 0.25f)
                    _looksLeft = !_looksLeft;
            }
        }
    }

    void LoadGame()
    {
        SceneManager.LoadSceneAsync("1Level", LoadSceneMode.Single);
    }
}
