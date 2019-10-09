using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetsogoMenu : MonoBehaviour {

    public GameObject ShopMenuEng;
    public GameObject ShopMenuRus;

    enum lang
    {
        Rus = 1,
        Eng = 2
    };

    // Use this for initialization
    void Start()
    {
        LanguageSettings();
    }

    void LanguageSettings()
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


}

