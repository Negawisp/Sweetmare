using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;

public class AdvertsInitialiser : MonoBehaviour {

    [SerializeField]
    string _gameId = "2983149";
    [SerializeField]
    bool _testMode = false;

    void Start()
    {
        //Debug.LogError("Ads now don't initialize.");
        Monetization.Initialize(_gameId, _testMode);
    }

    public void ShowPrivacyPolicy()
    {
        Application.OpenURL("https://www.freeprivacypolicy.com/privacy/view/7a7f49c0a52590d8a462cee4fd057ae1");
    }
}
