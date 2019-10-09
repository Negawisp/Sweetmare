using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweetManager : MonoBehaviour {



    public Transform theSweetGenerationPoint;
    public Transform theDestructionPoint;
    public ObjectPool SweetPooler;
    [SerializeField]
    private SpawnerController common_parameters;

    private float minimum_distance;
    private float distance;

    private float heightChange;

    public float Spawn_frequence;

	// Use this for initialization
	void Start () {
        //minimum_distance  = common_parameters.Minimum_distance;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Time.timeScale > 0.9)
        if (Random.Range(0, 1000) < Spawn_frequence)
        {
            if (theSweetGenerationPoint.transform.position.x > transform.position.x)
            {
                // Offset position of Object_Manager in such Vector // Random Height
                heightChange = Random.Range(-5, 5);
                transform.position = new Vector3(transform.position.x,
                                                 heightChange, transform.position.z);
 
            }
        }
		
	}

    void spawn_sweets ()
    {
        // This shit just make new Object after SweetGenerationPoint
        GameObject newSweet1 = SweetPooler.GetObject();
        newSweet1.transform.position = new Vector3(theSweetGenerationPoint.transform.position.x,
                                                  transform.position.y,
                                                  -2);
        newSweet1.transform.rotation = transform.rotation;
        newSweet1.SetActive(true);

        GameObject newSweet2 = SweetPooler.GetObject();
        newSweet2.transform.position = new Vector3(theSweetGenerationPoint.transform.position.x + 1f,
                                                  transform.position.y,
                                                  -2);
        newSweet2.transform.rotation = transform.rotation;
        newSweet2.SetActive(true);

        GameObject newSweet3 = SweetPooler.GetObject();
        newSweet3.transform.position = new Vector3(theSweetGenerationPoint.transform.position.x + 2f,
                                                  transform.position.y,
                                                  -2);
        newSweet3.transform.rotation = transform.rotation;
        newSweet3.SetActive(true);

        GameObject newSweet4 = SweetPooler.GetObject();
        newSweet4.transform.position = new Vector3(theSweetGenerationPoint.transform.position.x + 3f,
                                                  transform.position.y,
                                                  -2);
        newSweet4.transform.rotation = transform.rotation;
        newSweet4.SetActive(true);

        //common_parameters.Last_generation_position = transform.position;
    }
}
