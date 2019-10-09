﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Monetization;

[RequireComponent(typeof(Button))]
public class UnityAdsButton : MonoBehaviour
{

    public string placementId = "DeathScreen";
    private Button adButton;
    
    private string gameId = "2983149";

    void Start()
    {
        adButton = GetComponent<Button>();

        if (adButton) { adButton.onClick.AddListener(ShowAd); }
        if (Monetization.isSupported) { Monetization.Initialize(gameId, true); }
    }

    void Update()
    {
        if (adButton) { adButton.interactable = Monetization.IsReady(placementId); }
    }

    
    void ShowAd()
    {
        ShowAdCallbacks options = new ShowAdCallbacks();
        options.finishCallback = HandleShowResult;
        ShowAdPlacementContent ad = Monetization.GetPlacementContent(placementId) as ShowAdPlacementContent;
        ad.Show(options);
    }
    

    
    void HandleShowResult(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            FindObjectOfType<GameManager>().RewardForAd(placementId);
        }
        else if (result == ShowResult.Skipped)
        {
            Debug.LogWarning("The player skipped the video - DO NOT REWARD!");
        }
        else if (result == ShowResult.Failed)
        {
            Debug.LogError("Video failed to show");
        }
    }
    
}





