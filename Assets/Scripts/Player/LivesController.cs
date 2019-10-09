using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesController : MonoBehaviour {
    
    [SerializeField]
    private GameObject[] _lives;
    private Animator[] _animators;

    private GameManager _gameManager;
    
    private int _maxHealth;
    private int _health;
    
    
    void Start ()
    {
        _maxHealth = PlayerPrefs.GetInt("MaxHealth");

        _gameManager = FindObjectOfType<GameManager>();

        _animators = new Animator[_lives.Length];
        for (int i = 0; i < _lives.Length; i++)
        {
            _animators[i] = _lives[i].GetComponent<Animator>();
        }

        SetupLives(_maxHealth);
        _health = _maxHealth;
    }


    public int GetHit()
    {
        Debug.Log ("GOT HIT!");
        _health--;

        if (_health < 0 || _health >= _maxHealth)
        {
            Debug.Log("Fatal collision happened.");
            Die();
            return 0;
        }

        _animators[_health].SetTrigger("GetLost");

        return _health;
    }

    //Returns true if full health was on call, else returns false.
    public bool RestoreLife()
    {
        if (_health == _maxHealth)
            return true;

        if (_health < 0 || _health > _maxHealth)
        {
            Die();
            Debug.LogError ("Health is out of allowed span. There is code to be fixed.");
            return false;
        }
        
        _animators[_health].SetTrigger("Restore");
        _health++;
        return false;
    }

    public void SetupLives(int quantity)
    {
        for (int i = 0; i < quantity; i++)
            _lives[i].SetActive(true);
    }

    private void Die()
    {
        Debug.Log("Trying to die...");
        _gameManager.Die();
    }

    public void Revive()
    {
        _health = 0;
        RestoreLife();
    }
}
