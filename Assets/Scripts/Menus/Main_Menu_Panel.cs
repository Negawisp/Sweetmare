using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

//
/*
 * 
 * This class is needed for changing data from '1LEVEL' scene to 'MainMenu' scene.
 *
 */
//
public class Main_Menu_Panel : MonoBehaviour {
    
    private float _mainMenuDistanceCounter;
    private int _mainMenuSweetCounter;
    private int _mainMenuCakesCounter;
    private int _mainMenuChokoCounter;
    private int _mainMenuLolypopCounter;

    private int _mainMenuAllSweetCounter;
    private float _mainMenuRecordCounter;

    private int  _wasAdded = 0;

    public Text _mainMenuSweetText;

    public Text _mainMenuCakesText;

    public Text _mainMenuChokoText;
    public Text _mainMenuDistanceText;
    public Text _mainMenuLolypopText;
    public Text _mainMenuAllSweetsText;
    public Text _mainMenuRecordText;
    /*
    [SerializeField]
    public Text _mainMenuSweetText;
    [SerializeField]
    private Text _mainMenuCakesText;
    [SerializeField]
    private Text _mainMenuChokoText;
    [SerializeField]
    private Text _mainMenuDistanceText;
    [SerializeField]
    private Text _mainMenuLolypopText;
    [SerializeField]
    private Text _mainMenuAllSweetsText;
    [SerializeField]
    private Text _mainMenuRecordText;
*/
    public GameObject MainMenuEng;
    public GameObject MainMenuRus;

    enum lang
    {
        Rus = 1,
        Eng = 2
    };

    //public int ScoreSweetCount;

	// Use this for initialization
    void Start () {
        //_wasAdded = true;
        LanguageSettings();

        LoadGeneralKnowledge();


        Debug.Log("Main_Menu_Pamel is about to call LoadScores()!!!!");
        LoadScores();

        //ChangeGeneralKnowledge();

        //SaveGeneralKnowledge(); 

        TransformCounterinText();

        Debug.Log("Main_Menu_Pamel Stsrt function was completed");

	}

    void LanguageSettings()
    {
        if (PlayerPrefs.GetInt("Language") == (int)lang.Eng)
        {
            MainMenuEng.SetActive(true);
            MainMenuRus.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Language") == (int)lang.Rus)
        {
            MainMenuRus.SetActive(true);
            MainMenuEng.SetActive(false);
        }
    }

    // Load AllSweetCounter & Record to use it with current data
    void LoadGeneralKnowledge()
    {
        Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);

        _mainMenuAllSweetCounter = PlayerPrefs.GetInt("G_AllSweetScore");
        _mainMenuRecordCounter = PlayerPrefs.GetFloat("G_RecordScore");
    }


    void LoadScores()
    {
        Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name + " Distance " + _mainMenuDistanceCounter + " GetFloat: " + PlayerPrefs.GetFloat("DistanceScore"));

        Debug.Log("Sweet Cake Choko Loly" + PlayerPrefs.GetInt("SweetScore") + PlayerPrefs.GetInt("CakeScore") + PlayerPrefs.GetInt("ChokoScore") + PlayerPrefs.GetInt("LolypopScore"));

        _mainMenuDistanceCounter = PlayerPrefs.GetFloat("DistanceScore");

        _mainMenuSweetCounter = PlayerPrefs.GetInt("SweetScore");
        _mainMenuCakesCounter = PlayerPrefs.GetInt("CakeScore");
        _mainMenuChokoCounter = PlayerPrefs.GetInt("ChokoScore");
        _mainMenuLolypopCounter = PlayerPrefs.GetInt("LolypopScore");

    }
    /// <summary>
    /// May be it is better to do in Score Manager
    /// </summary>
    void ChangeGeneralKnowledge() 
    {
        Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
            

            Debug.Log(" SweetQuality " + "Previous " + _mainMenuAllSweetCounter + " Current " + _mainMenuSweetCounter);
            _mainMenuAllSweetCounter += _mainMenuSweetCounter;

        if (_mainMenuDistanceCounter > _mainMenuRecordCounter)
        {
            Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name + " Oh, you have a new Record " + "Previous Record " + _mainMenuRecordCounter + " Current Record " + _mainMenuDistanceCounter);
            _mainMenuRecordCounter = _mainMenuDistanceCounter;
        }
    }

    void SaveGeneralKnowledge()
    {       
        Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);

        PlayerPrefs.SetInt("G_AllSweetScore", _mainMenuAllSweetCounter);
        PlayerPrefs.SetFloat("G_RecordScore", _mainMenuRecordCounter);
    }

 


    void TransformCounterinText()
    {
        Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);

        _mainMenuDistanceText.text = " " + Mathf.Round(_mainMenuDistanceCounter);

        _mainMenuSweetText.text = " " + _mainMenuSweetCounter;
        _mainMenuCakesText.text = " " + _mainMenuCakesCounter;
        _mainMenuChokoText.text = " " + _mainMenuChokoCounter;
        _mainMenuLolypopText.text = " " + _mainMenuLolypopCounter;


        _mainMenuAllSweetsText.text = " " + _mainMenuAllSweetCounter;
        _mainMenuRecordText.text = " " + Mathf.Round(_mainMenuRecordCounter);


    }


    private void OnDestroy()
    {
        Debug.Log("Menupanel was destroyed!");
    }



}
/*  void WorkwithGeneralKnowledge()
   {
       //Load
       LoadGeneralKnowledge();
       Debug.Log(" SweetQuality " + "Previous " + _mainMenuAllSweetCounter + " Current " + (_mainMenuAllSweetCounter + _mainMenuSweetCounter) );

       //Change
       _mainMenuAllSweetCounter += _mainMenuSweetCounter;

       if (_mainMenuDistanceCounter > _mainMenuRecordCounter)
       {
           Debug.Log(" Oh, you have a new Record " + "Previous Record " + _mainMenuRecordCounter + " Current Record " + _mainMenuDistanceCounter);
           _mainMenuRecordCounter = _mainMenuDistanceCounter;
       }
       //Save
       SaveGeneralKnowledge();
   }*/
