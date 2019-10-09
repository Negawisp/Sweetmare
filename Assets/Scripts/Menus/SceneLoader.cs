using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour 
{
    [SerializeField]
    private string _sceneToLoad;

    [SerializeField]
    private SoundManager _soundManager;
    
    public void LoadSingle()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(_sceneToLoad, LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadAdditive()
    {
        if (_soundManager) _soundManager.StopGeneralMelody();
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(_sceneToLoad, LoadSceneMode.Additive);
    }
}
