using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Pause_Menu : MonoBehaviour {

    private ScoreManager _scoreManager;

    public GameObject pauseScreenRus;
    public GameObject pauseScreenEng;

    [SerializeField]
    private GameObject _pauseMenuPanel;

    private SoundManager _theSoundManager;

    [SerializeField]
    private GameObject[] _buttonEngArr;
    [SerializeField]
    private GameObject[] _buttonRusArr;

    private GameManager _gameManager;

    enum  lang
    {
        Rus = 1,
        Eng = 2
    };

    
    void Start () {
        _gameManager = FindObjectOfType<GameManager>();
        _scoreManager = FindObjectOfType<ScoreManager>();
        _theSoundManager = FindObjectOfType<SoundManager>();
	}

     
    public void Pause()
    {
        _scoreManager.UpdatePauseMenu();

        Time.timeScale += 1f;
        if (Time.timeScale > 1.5)
        {
            Time.timeScale = 0f;
        }

        _theSoundManager.StopGeneralMelody();
        _pauseMenuPanel.SetActive(true);

        if (PlayerPrefs.GetInt("Language") == (int)lang.Eng)
        {
            pauseScreenEng.SetActive(true);
            pauseScreenRus.SetActive(false);

            for (int i = 0; i < _buttonEngArr.Length; i++)
            {
                _gameManager.HalfTransparency(_buttonRusArr[i]);
            }
        }
        else if (PlayerPrefs.GetInt("Language") == (int)lang.Rus)
        {
            pauseScreenRus.SetActive(true);
            pauseScreenEng.SetActive(false);

            for (int i = 0; i < _buttonEngArr.Length; i++)
            {
                _gameManager.HalfTransparency(_buttonEngArr[i]);
            }
        }

    }

    public void Resume()
    {
        _pauseMenuPanel.SetActive(false);
        _theSoundManager.PlayGeneralMelody();
        Time.timeScale = 1f;
    }

    public void English()
    {
        pauseScreenRus.SetActive(false);
        pauseScreenEng.SetActive(true);
     
        for (int i = 0; i < _buttonEngArr.Length; i++)
        {
            _gameManager.FullTransparency(_buttonEngArr[i]);
            _gameManager.HalfTransparency(_buttonRusArr[i]);
        }

        PlayerPrefs.SetInt("Language", (int)lang.Eng);

    }
	
    public void Russian()
    {
        pauseScreenEng.SetActive(false);
        pauseScreenRus.SetActive(true);

        for (int i = 0; i < _buttonEngArr.Length; i++)
        {
            _gameManager.HalfTransparency(_buttonEngArr[i]);
            _gameManager.FullTransparency(_buttonRusArr[i]);
        }

        PlayerPrefs.SetInt("Language", (int)lang.Rus);
    }


}
