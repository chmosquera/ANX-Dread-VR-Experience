using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hallway_Zoom : MonoBehaviour {
    [SerializeField] private Transform target1;
    [SerializeField] private Transform target2;
    [SerializeField] private Transform hallway;
    //private float initialHallwaySize;
    private float initialDistance1;
    private float initialDistance2;
    private float lastPosition;
    private float scaleCount;
    private float xCompare;
    private int state;

    /* Chanelle's edits */
    public float duration = 5.0f;
    public float startTime = 2.0f;
    public AudioClip warpSound;

    private float t = 0;
    private float timer = 0.0f;
    private bool beginWarp = false;


    // Use this for initialization
    void Start ()
    {
        Initialize();
	}
	
    void Initialize()
    {
        // distance between target and person is initialized
        initialDistance1 = target1.position.z - transform.position.z;
        initialDistance2 = target2.position.z - transform.position.z;
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
        //float currentSpeed = (transform.position.z - lastPosition) / Time.deltaTime;
        // new last position
        //lastPosition = transform.position.z;
        // distance between targets and person is computed
        //float currentDistance1 = target1.position.z - transform.position.z;
        //float currentDistance2 = target2.position.z - transform.position.z;

        // arbitrary scalar used to make it look the best
        //float zScaleBy = zScale(currentSpeed);
        float xScaleBy = xScale();
        timer += Time.deltaTime;


        if (timer >= startTime && timer <= (startTime + duration))
        {
            if (beginWarp == false){
                AudioSource audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.PlayOneShot(warpSound);
                beginWarp = true;
            }

            t = (timer-startTime) / duration;
            hallway.localScale += new Vector3(0, 0, t * 0.01f);   

        }

        // alternating x size
        wobble(xScaleBy);
        
    }

    private float zScaleBy(float speed)
    {
        return Time.deltaTime / 700f;
    }

    private float xScale()
    {
        return -(2.0f) / 4000f;
    }

    private void wobble(float xScaleBy)
    {
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


}

