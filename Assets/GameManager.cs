using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private SpawnerController _spawnerController;
    private ScoreManager _scoreManager;
    [SerializeField]
    private DeathScreen _deathMenu;
    private LivesController _livesController;
    private KidAnimatorParameterSetter _kidAnimatorSetter;
    private ActiveObjectsTracker _tracker;

    private Timer _timer;
    public GameObject JustDiePanel;

    [SerializeField]
    private GameObject _advButtonEng;
    [SerializeField]
    private GameObject _advButtonRus;

    [SerializeField]
    private GameObject _pauseButton;

    private bool _kidIsAlive = true;
    private int _deathsCounter;

    private SoundManager _soundManager;

    void Start()
    {
        _deathsCounter = 0;
        _timer = FindObjectOfType<Timer>();

        _scoreManager = FindObjectOfType<ScoreManager>();
        _livesController = FindObjectOfType<LivesController>();
        _tracker = FindObjectOfType<ActiveObjectsTracker>();
        _kidAnimatorSetter = FindObjectOfType<KidAnimatorParameterSetter>();
        _spawnerController = FindObjectOfType<SpawnerController>();
        _soundManager = FindObjectOfType<SoundManager>();
    }
  
    public void Die()
    {
        _deathsCounter++;
        _spawnerController.DecreaseTastyPossibility(_deathsCounter);
        _kidIsAlive = false;

        Time.timeScale = 0;

        _pauseButton.SetActive(false);
        _timer.TimerOn();
        //StartCoroutine(TestTimerCoroutine());
    }

    
    public void AfterTimer()
    {
        JustDiePanel.SetActive(false);
        if (!_kidIsAlive)
        {
            _scoreManager.SaveScore();
            _scoreManager.LoadScore();
            _deathMenu.Launch();
        }
    }
    

    IEnumerator TestTimerCoroutine()
    {

        _timer.TimerOn();
        
        yield return new WaitForSecondsRealtime(0f);

        _pauseButton.SetActive(true);

        if (!_kidIsAlive)
        {
            _scoreManager.SaveScore();
            _scoreManager.LoadScore();
            _deathMenu.Launch();
            _soundManager.StopGeneralMelody();
            PlayerPrefs.SetInt("FullBodySkin", (int)CostumeType.Default);
        }


    }



    public void RewardForAd(string placementID)
    {
        if (placementID.Length < 2)
        {
            Debug.LogError ("Placement ID is too short. Please recheck all your IDs.");
            return;
        }


        if (placementID.Equals("DeathScreen"))
        {
            StartCoroutine(Revive());
        }
        else
        if (placementID.Equals("ExtraSweets"))
        {
            AddExtraSweets();
        }
    }

    private IEnumerator Revive()
    {
        _kidIsAlive = true;
        _livesController.Revive();
        _kidAnimatorSetter.SetTrigger("Revive");
        _tracker.KillEachActiveObstacle();

        _deathMenu.gameObject.SetActive(false);
        JustDiePanel.SetActive(false);

        yield return new WaitForSecondsRealtime(1f);

        Time.timeScale = 1;
    }

    private void AddExtraSweets()
    {
        _scoreManager.AddAdvertizementSweets(100);
        _scoreManager.LoadScore();

        //Making Button less visiable
        Color color = new Color(255, 255, 255, 0.2f);

        _advButtonEng.gameObject.GetComponent<Image>().color = color;
        _advButtonEng.gameObject.GetComponent<Button>().interactable = false;

        _advButtonRus.gameObject.GetComponent<Image>().color = color;
        _advButtonRus.gameObject.GetComponent<Button>().interactable = false;


    }

    // Intensity of the GameObj Color 100%
    public void FullTransparency(GameObject Obj)
    {
        if (Obj.gameObject.GetComponent<Image>().color.a.Equals(0.5f))
        {
            Color color = new Color(255, 255, 255, 1f);
            Obj.gameObject.GetComponent<Image>().color = color;
        }
    }

    // Intensity of the GameObj Color 50%
    public void HalfTransparency(GameObject Obj)
    {
        if (Obj.gameObject.GetComponent<Image>().color.a.Equals(1f))
        {
            Color color = new Color(255, 255, 255, 0.5f);
            Obj.gameObject.GetComponent<Image>().color = color;
        }
    }
}