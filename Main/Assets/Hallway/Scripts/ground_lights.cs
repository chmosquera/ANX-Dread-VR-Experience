using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Light))]
public class ground_lights : MonoBehaviour
{

    //[SerializeField] bool isBroken = true;
    [SerializeField] Light myLight;
//[SerializeField] float iStep = 0.05f, iMax = 7.0f, iMin = 0.0f;
//public door myDoor;
    float rotateSpeed = 500f;
    private float zangle;
    private float yangle;

    // Use this for initialization
    void Start()
    {
        myLight = this.GetComponent<Light>();
        yangle = transform.rotation.y;
        zangle = transform.rotation.z;
        if (myLight == null) Debug.LogError("ground_lights.cs requires a light component.");

    }

    //bool reachedIMax = false;
    void Update()
    {
        myLight.color = Color.red;
        transform.Rotate(new Vector3(Time.deltaTime * rotateSpeed, yangle, zangle));
        // pulsing intensity
        //if (myLight.intensity > iMax) reachedIMax = true;
        //else if (myLight.intensity < iMin) reachedIMax = false;

        //if (reachedIMax) myLight.intensity -= iStep;
        //else myLight.intensity += iStep;

            

    }
}
