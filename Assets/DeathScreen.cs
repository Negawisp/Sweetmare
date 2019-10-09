using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class DeathScreen : MonoBehaviour {

    private float _deathMenuDistanceCounter;
    private int _deathMenuSweetCounter;
    private int _deathMenuCakesCounter;
    private int _deathMenuChokoCounter;
    private int _deathMenuLolypopCounter;
    private int _deathMenuAllSweetCounter;
    private float _deathMenuRecordCounter;

    public Text _deathMenuSweetText;
    public Text _deathMenuCakesText;
    public Text _deathMenuChokoText;
    public Text _deathMenuDistanceText;
    public Text _deathMenuLolypopText;
    public Text _deathMenuAllSweetsText;
    public Text _deathMenuRecordText;

    public GameObject DeathMenuEng;
    public GameObject DeathMenuRus;

    [SerializeField]
    private GameObject DeathMenuPanel;

    enum Language
    {
        Rus = 1,
        Eng = 2
    };


    public void Launch()
    {
        DeathMenuPanel.SetActive(true);
        SetLanguage();

        UpdateCounters();

        Debug.Log("Death_Menu_Panel Stsrt function was completed");

    }

    private void SetLanguage()
    {
        if (PlayerPrefs.GetInt("Language") == (int)Language.Eng)
        {
            DeathMenuEng.SetActive(true);
            DeathMenuRus.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Language") == (int)Language.Rus)
        {
            DeathMenuRus.SetActive(true);
            DeathMenuEng.SetActive(false);
        }
    }


    public void LoadScore(float distance, int sweetScore, int cakeScore, int chocoScore, int lollipopScore)
    {
        _deathMenuDistanceCounter = distance;

        _deathMenuSweetCounter = sweetScore;
        _deathMenuCakesCounter = cakeScore;
        _deathMenuChokoCounter = chocoScore;
        _deathMenuLolypopCounter = lollipopScore;
        
        _deathMenuAllSweetCounter = PlayerPrefs.GetInt("G_AllSweetScore");
        _deathMenuRecordCounter = PlayerPrefs.GetFloat("G_RecordScore");

        UpdateCounters();
    }

    public void UpdateCounters()
    {
        Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);

        _deathMenuDistanceText.text = " " + Mathf.Round(_deathMenuDistanceCounter);

        _deathMenuSweetText.text = " " + _deathMenuSweetCounter;
        _deathMenuCakesText.text = " " + _deathMenuCakesCounter;
        _deathMenuChokoText.text = " " + _deathMenuChokoCounter;
        _deathMenuLolypopText.text = " " + _deathMenuLolypopCounter;


        _deathMenuAllSweetsText.text = " " + _deathMenuAllSweetCounter;
        _deathMenuRecordText.text = " " + Mathf.Round(_deathMenuRecordCounter);
    }

}



