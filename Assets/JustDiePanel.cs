using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustDiePanel : MonoBehaviour {

    public GameObject ButtonRus;
    public GameObject ButtonEng;

    public GameObject LabelRus;
    public GameObject LabelEng;

    enum lang
    {
        Rus = 1,
        Eng = 2
    };
	// Use this for initialization
	void Start () {
        
        if (PlayerPrefs.GetInt("Language") == (int)lang.Eng)
        {
            ButtonEng.SetActive(true);
            ButtonRus.SetActive(false);
            LabelEng.SetActive(true);
            LabelRus.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Language") == (int)lang.Rus)
        {
            ButtonRus.SetActive(true);
            ButtonEng.SetActive(false);
            LabelRus.SetActive(true);
            LabelEng.SetActive(false);
        }
	}
	
}
