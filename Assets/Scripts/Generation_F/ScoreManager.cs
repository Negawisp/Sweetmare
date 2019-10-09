using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class ScoreManager : MonoBehaviour {
    

    [SerializeField]
    private Text _sweetText;
    [SerializeField]
    private Text _distanceText;

    private int   _sweetsScore;
    private float _distanceScore;
    
    [SerializeField]
    private Text _pauseSweetText;
    [SerializeField]
    private Text _pauseDistanceText;
    [SerializeField]
    private DeathScreen _deathScreen;


    [SerializeField]
    private HorizontalParameters _kidHorizontalParameters;

    [SerializeField]
    private float _pointsPerMeters;

    private SweetCounter _sweetCounter;
    private int[] _boostsCollected;


    private int[] _sweetsForBoost;
    [SerializeField]
    private int _sweetsForCake;
    [SerializeField]
    private int _sweetsForChocolate;
    [SerializeField]
    private int _sweetsForLollipop;


    void Start ()
    {
        _sweetCounter = GetComponentInChildren<SweetCounter>();

        if (_sweetsForLollipop <= 0)
            _sweetsForLollipop = PlayerPrefs.GetInt("LolypopSweets");

        _boostsCollected = new int[(int)BoostType.boostTypesAmmount];

        _sweetsForBoost  = new int[(int)BoostType.boostTypesAmmount];

        _sweetsForBoost[(int)BoostType.cake]      = _sweetsForCake;
        _sweetsForBoost[(int)BoostType.chocolate] = _sweetsForChocolate;
        _sweetsForBoost[(int)BoostType.lollipop]  = _sweetsForLollipop;
    }
    
    void FixedUpdate()
    {
        _distanceScore += _pointsPerMeters * _kidHorizontalParameters.VelocityX * Time.fixedDeltaTime;
        _distanceText.text = " " + Mathf.Round(_distanceScore);
    }
    

    public void AddBoost(BoostType boostType, bool giveSweetsCondition = true)
    {
        _boostsCollected[(int)boostType]++;
        if (giveSweetsCondition)
            AddSweets (_sweetsForBoost[(int)boostType]);
    }

    public void AddSweets(int ammount)
    {
        _sweetsScore += ammount;
        _sweetCounter.AddSweetsToQueue(ammount);
    }
    
    private void IncreaseSavedSweets (int value)
    {
        int _spendableSweets = PlayerPrefs.GetInt("G_AllSweetScore");
        _spendableSweets += value;
        PlayerPrefs.SetInt("G_AllSweetScore", _spendableSweets);
    }

    private void UpdateDistanceRecord (float value)
    {
        float _recordDistance = PlayerPrefs.GetFloat("G_RecordScore");

        if (value > _recordDistance)
        {
            _recordDistance = value;
        }

        PlayerPrefs.SetFloat("G_RecordScore", _recordDistance);
    }
    
    public void SaveScore()
    {
        IncreaseSavedSweets(_sweetsScore);
        UpdateDistanceRecord(_distanceScore);
    }

    public void LoadScore()
    {
        _deathScreen.LoadScore(_distanceScore, 
                               _sweetsScore,
                               _boostsCollected[(int)BoostType.cake],
                               _boostsCollected[(int)BoostType.chocolate],
                               _boostsCollected[(int)BoostType.lollipop]);
    }

    public void UpdatePauseMenu()
    {
        _pauseSweetText.text    = " " + _sweetsScore;
        _pauseDistanceText.text = " " + Mathf.Round(_distanceScore);
    }


    public void AddAdvertizementSweets(int value)
    {
        _sweetsScore += value;
        IncreaseSavedSweets(value);
    }
}

