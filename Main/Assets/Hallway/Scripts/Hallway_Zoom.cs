using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hallway_Zoom : MonoBehaviour {
    [SerializeField] private Transform target;
    [SerializeField] private Transform hallway;
    //private float initialHallwaySize;
    private float initialDistance;
    private float lastPosition;
    private float scaleCount;
    private float xCompare;
    private int state;


    // Use this for initialization
    void Start ()
    {
        Initialize();
	}
	
    void Initialize()
    {
        // distance between target and person is initialized
        initialDistance = target.position.z - transform.position.z;
        // the last position is initialized to the current position the person is at
        lastPosition = transform.position.z;

        xCompare = hallway.localScale.x;
        scaleCount = 0;
        state = 0;
        //float currentHallwayPos = hallway.position;
    }

	// Update is called once per frame
	void Update ()
    {
        // speed is change in position over time
        float currentSpeed = (transform.position.z - lastPosition) / Time.deltaTime;
        // new last position
        lastPosition = transform.position.z;
        // distance between target and person is computed
        float currentDistance = target.position.z - transform.position.z;
        // arbitrary scalar used to make it look the best
        float zScaleBy = zScale(currentSpeed);
        float xScaleBy = xScale();
        if (currentDistance >= 0)
        {
            hallway.localScale += new Vector3(0, 0, zScaleBy);
        }


        // alternating x size
        if (state == 0)
        {
            hallway.localScale += new Vector3(-xScaleBy, 0, 0);
            scaleCount += (hallway.localScale.x - xCompare);
            //print("Shrinking count: " + scaleCount);
            if (scaleCount >= 0.1f)
            {
                //print("Changing to state 1");
                state = 1;
                scaleCount = 0;
            }
        }
        else if (state == 1)
        {
            hallway.localScale += new Vector3(xScaleBy, 0, 0);
            scaleCount += (xCompare - hallway.localScale.x);
            //print("Growing count: " + scaleCount);
            if (scaleCount >= 0.05f)
            {
                //print("Changing to state 0");
                state = 0;
                scaleCount = 0;
            }
        }
    }

    float zScale(float speed)
    {
        return (speed) / 800f;
    }

    float xScale()
    {
        return -(2.0f) / 4000f;
    }
}

