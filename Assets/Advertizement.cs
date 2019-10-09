using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;

public class Advertizement : MonoBehaviour
{
    public string _placementId;
    private string _gameId = "2983149";

    private GameManager _gameManager;
    
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    public void ShowAd()
    {
        //Debug.LogError("IF YOU SEE THIS, SET UP THE ADVERTISEMENTS ONCE AGAIN!");
        
        ShowAdCallbacks options = new ShowAdCallbacks();

        options.finishCallback = HandleShowResult;
        ShowAdPlacementContent ad = Monetization.GetPlacementContent(_placementId) as ShowAdPlacementContent;
        ad.Show(options);
        
    }

    
    void HandleShowResult(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            _gameManager.RewardForAd(_placementId);
        }
        else if (result == ShowResult.Skipped)
        {
            Debug.LogWarning("Player skipped the video - DO NOT REWARD!");
        }
        else if (result == ShowResult.Failed)
        {
            Debug.LogError("Video failed to show");
        }
    }
    
}