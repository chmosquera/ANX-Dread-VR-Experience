using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hallway_Zoom : MonoBehaviour {
    [SerializeField] private Transform target;
    [SerializeField] private Transform hallway;
    //private float initialHallwaySize;
    private float initialDistance;
    private float lastPosition;


	// Use this for initialization
	void Start ()
    {
        Initialize();
	}
	
    void Initialize()
    {
        initialDistance = target.position.z - transform.position.z;
        lastPosition = transform.position.z;
        //float currentHallwayPos = hallway.position;
    }

	// Update is called once per frame
	void Update ()
    {
        float currentSpeed = (transform.position.z - lastPosition) / Time.deltaTime;
        lastPosition = transform.position.z;
        float currentDistance = target.position.z - transform.position.z;
        float whatToScaleBy = computeScale(currentSpeed);
        //float whatToTransBy = computeTrans();
        //print(currentSpeed);
        if (currentDistance >= 0)
        {
            hallway.localScale += new Vector3(0, 0, whatToScaleBy);
        }
	}

    float computeScale(float speed)
    {

        return (speed) / 750f;
    }
}

