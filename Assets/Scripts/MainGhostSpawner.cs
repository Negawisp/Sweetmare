using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGhostSpawner : MonoBehaviour {


    Animator ghost_animator;
    [SerializeField]
    ObjectSpawner _ghostGenerator;

	// Use this for initialization
	void Start () {
        ghost_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.G))
            Spawn();
    }

    void Spawn ()
    {
        ghost_animator.SetTrigger("Spawn");

        _ghostGenerator.Spawn(ObjectSpawner.UseInternalLastY, 0);
    }
    
    public Vector3 GetPosition()
    {
        return gameObject.transform.position;
    }
}
