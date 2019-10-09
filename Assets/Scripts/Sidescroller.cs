using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sidescroller : MonoBehaviour {

    // The camera follows the player on the offset set by offset_x

    [SerializeField]
    private ObjectPool[] _poolers;
    [SerializeField]
    private SpawnerController _generatorsParameters;

    public float offset_x;
    [SerializeField]
    private Transform _player;
    [SerializeField]
    placeBackgroundToZero _backgrounds;

    [SerializeField]
    private float _xToRevind;

    // Use this for initialization
    void Start()
    {
        _poolers = FindObjectsOfType<ObjectPool>();
        //_generatorsParameters = FindObjectOfType<Generators_common_parameters>();

        set_offset();
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    // Update is called once per frame
    void Update()
    {
        if (_player != null)
        {
            Vector3 pos = transform.position;
            pos.x = _player.position.x + offset_x;
            transform.position = pos;
        }
    }
    

    bool set_offset()
    {
        GameObject player_go = GameObject.FindGameObjectWithTag("Player");
        if (player_go == null)
        {
            Debug.LogError("Couldn't find an object w\\ tag \"Kid\".");
            return false;
        }

        _player = player_go.transform;
        offset_x = transform.position.x - _player.position.x;
        return true;
    }
}
