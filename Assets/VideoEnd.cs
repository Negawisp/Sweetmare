using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoEnd : MonoBehaviour {
    private bool _startedPlaying;
    [SerializeField]
    private VideoPlayer _player;
    [SerializeField]
    private GameObject _canvas;

    void Awake ()
    {
    }

    // Use this for initialization
    void Start()
    {
        _player.loopPointReached += VideoFinished;
        _startedPlaying = false;



        //Debug.Log("");
    }

    void VideoFinished(UnityEngine.Video.VideoPlayer vp)
    {
        Debug.Log("AAAAA");
        //SceneManager.LoadScene("LetsgoMenu", LoadSceneMode.Single);
        this.enabled = false;
        _player.enabled = false;
        _canvas.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        if (_player.isPlaying && !_startedPlaying)
            _startedPlaying = true;

		if (!_player.isPlaying && _startedPlaying)
            SceneManager.LoadScene("LetsgoMenu", LoadSceneMode.Single);
            */
    }
}
