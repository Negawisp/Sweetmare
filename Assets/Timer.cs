using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour {
    
    public GameObject JustDiePanel;
    public Text TimeText;

    public bool timerEnabled;

    
	// Update is called once per frame
	void Update () {
	}

    public void TimerOn()
    {
        JustDiePanel.SetActive(true);
        StartCoroutine(StartCountdown(5));
    }

    float currCountdownValue;
    public IEnumerator StartCountdown(float countdownValue = 5)
    {
        currCountdownValue = countdownValue;

        while (currCountdownValue > 0)
        {
            Debug.Log("Countdown: " + currCountdownValue);
            TimeText.text = " " + currCountdownValue;
            currCountdownValue--;
            yield return new WaitForSecondsRealtime(1.0f);
        }

        FindObjectOfType<GameManager>().AfterTimer();


        JustDiePanel.SetActive(false);
    }
}