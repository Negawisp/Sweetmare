using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathScreen_SoundManager : MonoBehaviour {

    [SerializeField]
    private AudioSource _buttonsSound;

    private bool _soundsDisabled;
    private bool _musicDisabled;

    private void Start()
    {
        LoadSoundSettings();
    }

    private void LoadSoundSettings()
    {
        _soundsDisabled = (PlayerPrefs.GetInt("Sounds") == (int)SoundSwitch.SoundDisabled);
        _musicDisabled = (PlayerPrefs.GetInt("Melody") == (int)SoundSwitch.MusicDisabled);


    }

    public void PlayButtonSound()
    {
        if (!_soundsDisabled)
        {
            Debug.Log("PUSH *click*");
            _buttonsSound.Play();
        }
    }
}
