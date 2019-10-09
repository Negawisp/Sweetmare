using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SweetCounter : MonoBehaviour {

    [SerializeField]
    private AudioSource SweetSound;
    [SerializeField]
    private SoundManager theSoundManager;

    [SerializeField]
    private Text _sweetText;
    private int _sweetsOnCounter;
    private int _sweetsQueue;
    private float _lastAddedSweetTime;
    [SerializeField]
    private float _sweetCooldown;
    
    [SerializeField]
    private Animator _sweetCounterAnimator;


    // Use this for initialization
    void Start () {
        _sweetText = GetComponentInChildren<Text>();
        _sweetsOnCounter = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (_sweetsQueue > 0 && Time.time - _lastAddedSweetTime > _sweetCooldown)
        {
            _sweetsQueue--;
            _lastAddedSweetTime = Time.time;
            AddSweet();
        }
    }

    private void AddSweet()
    {
        theSoundManager.PlaySweetSound();
        _sweetCounterAnimator.SetTrigger("SweetPickup");
        _sweetsOnCounter++;
        _sweetText.text = " " + _sweetsOnCounter;
    }



    public void AddSweetsToQueue(int ammount)
    {
        _sweetsQueue += ammount;
    }
}
