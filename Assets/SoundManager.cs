using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundManager : MonoBehaviour {
    
    [SerializeField]
    private AudioSource _sweetSound;
    [SerializeField]
    private AudioSource _boostSound;
    [SerializeField]
    private AudioSource _accelerationSound;
    [SerializeField]
    private AudioSource _buttonsSound;
    [SerializeField]
    private AudioSource _generalMelody;
    private AudioListener _listener;

    [SerializeField]
    private GameObject _gameobjectSounds;
    [SerializeField]
    private GameObject _gameobjectMelody;

    [SerializeField]
    private GameObject[] _buttonSoundsArr;
    [SerializeField]
    private GameObject[] _buttonMelodyArr;

    private GameManager _gameManager;

    


    public void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _listener = GetComponent<AudioListener>();

        LoadSoundSettings();
    }

    public void PlaySweetSound()
    {
        _sweetSound.Play();
    }

    public void PlayBoostSound()
    {
        _boostSound.Play();
    }

    public void PlayAccelerationSound()
    {
        _accelerationSound.Play();
    }

    public void PlayButtonSound()
    {
        _buttonsSound.Play();
    }

    public void PlayGeneralMelody()
    {
        _generalMelody.Play();
    }

    public void SwitchingSound()
    {
        switch (PlayerPrefs.GetInt("Sounds"))
        {
            case (int)SoundSwitch.SoundEnabled:
                {
                    _gameobjectSounds.SetActive(false);

                    SetTransparrency(_buttonSoundsArr, false);
          
                    PlayerPrefs.SetInt("Sounds", (int)SoundSwitch.SoundDisabled);
                    break;
                }
            case (int)SoundSwitch.SoundDisabled:
                {
                    _gameobjectSounds.SetActive(true);

                    SetTransparrency(_buttonSoundsArr, true);

                    PlayerPrefs.SetInt("Sounds", (int)SoundSwitch.SoundEnabled);
                    break;
                }
            default:
                {
                    _gameobjectSounds.SetActive(true);

                    SetTransparrency(_buttonSoundsArr, true);

                    PlayerPrefs.SetInt("Sounds", (int)SoundSwitch.SoundEnabled);
                    break;
                }
        }
    }

    public void SwitchingMelody()
    {
        switch (PlayerPrefs.GetInt("Melody"))
        {
            case (int)SoundSwitch.MusicEnabled:
                {
                    _gameobjectMelody.SetActive(false);
                    
                    SetTransparrency(_buttonMelodyArr, false);

                    PlayerPrefs.SetInt("Melody", (int)SoundSwitch.MusicDisabled);
                    break;
                }
            case (int)SoundSwitch.MusicDisabled:
                {
                    _gameobjectMelody.SetActive(true);

                    SetTransparrency(_buttonMelodyArr, true);

                    PlayerPrefs.SetInt("Melody", (int)SoundSwitch.MusicEnabled);
                    break;
                }
            default:
                {
                    _gameobjectMelody.SetActive(true);

                    SetTransparrency(_buttonMelodyArr, true);

                    PlayerPrefs.SetInt("Melody", (int)SoundSwitch.MusicEnabled);
                    break;
                }
        }
    }

    public void StopGeneralMelody()
    {
        //_generalMelody.Stop();
        _generalMelody.Pause();
        Debug.Log("ASDgfdg");
        _listener.enabled = false;
    }


    private void LoadSoundSettings()
    {
        bool soundsDisabled = (PlayerPrefs.GetInt("Sounds") == (int)SoundSwitch.SoundDisabled);
        bool musicDisabled = (PlayerPrefs.GetInt("Melody") == (int)SoundSwitch.MusicDisabled);

        _gameobjectSounds.SetActive(!soundsDisabled);
        _gameobjectMelody.SetActive(!musicDisabled);


        SetTransparrency(_buttonMelodyArr, !musicDisabled);
        SetTransparrency(_buttonSoundsArr, !soundsDisabled);
    }


    //Dunno whether GaeManager was changed in 01.03.19 collab, thus I write this function here.
    private void SetTransparrency(GameObject[] buttons, bool active)
    {
        if (active)
        {
            for (int i = 0; i < buttons.Length; i++)
                _gameManager.FullTransparency(buttons[i]);
        }
        else
        {
            for (int i = 0; i < _buttonMelodyArr.Length; i++)
                _gameManager.HalfTransparency(buttons[i]);
        }
    }
}
