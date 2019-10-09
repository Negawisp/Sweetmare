using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class FirstLaunch : MonoBehaviour {

    [SerializeField]
    private VideoPlayer _videoPlayer;
    [SerializeField]
    private GameObject _canvas;

    private string FirstLaunchName = "FLaunch";

    void Awake () {

        Time.timeScale = 1f;
        
        if (PlayerPrefs.GetInt("BuggedLanguage") == 0)
        {
            PlayerPrefs.SetInt(FirstLaunchName, 0);
            PlayerPrefs.SetInt("BuggedLanguage", 1);
        }

        FirstLaunchSetup();
        SkinSetup();
    }

    private void FirstLaunchSetup()
    {
        if (PlayerPrefs.GetInt(FirstLaunchName) == 0)
        {
            int level = 0;
            PlayerPrefs.SetInt("Lolypop" + "Level", level);
            PlayerPrefs.SetInt("LolypopSweets", 4);

            PlayerPrefs.SetInt("HP" + "Level", level);
            PlayerPrefs.SetInt("MaxHealth", 3);

            PlayerPrefs.SetInt("Cake" + "Level", level);
            PlayerPrefs.SetInt("SpeedUpDuration", 1);

            PlayerPrefs.SetInt("G_AllSweetScore", 0);

            PlayerPrefs.SetInt("Language", (int)1);

            PlayerPrefs.SetInt(FirstLaunchName, 1);

            _canvas.SetActive(false);
        }
        else
            _videoPlayer.enabled = false;
    }

    private void SkinSetup()
    {
        PlayerPrefs.SetInt("FullBodyType",  (int)CostumeType.Default);
        PlayerPrefs.SetInt("BodyType",      (int)CostumeType.None);
        PlayerPrefs.SetInt("HeadType",      (int)CostumeType.None);
    }
}
