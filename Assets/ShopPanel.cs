using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopPanel : MonoBehaviour {

    [SerializeField] private int _shopMenuAllSweetCounter;
    [SerializeField] private Text _shopMenuAllSweetCounterText;

    public GameObject ShopMenuEng;
    public GameObject ShopMenuRus;

    enum lang
    {
        Rus = 1,
        Eng = 2
    };

	// Use this for initialization
	void Start () {
        LanguageSettings();
        LoadGeneralKnowledge();

        UpdateSweetCounter();
	}
	
    public void UpdateSweetCounter()
    {
        _shopMenuAllSweetCounterText.text = " " + Mathf.Round(_shopMenuAllSweetCounter);

    }


    public void LanguageSettings()
    {
        if (PlayerPrefs.GetInt("Language") == (int)lang.Eng)
        {
            ShopMenuEng.SetActive(true);
            ShopMenuRus.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Language") == (int)lang.Rus)
        {
            ShopMenuRus.SetActive(true);
            ShopMenuEng.SetActive(false);
        }
    }

    public void LoadGeneralKnowledge()
    {
        Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);

        _shopMenuAllSweetCounter = PlayerPrefs.GetInt("G_AllSweetScore");
    }

}
