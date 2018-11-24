using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class AlarmLight : MonoBehaviour {

    [SerializeField] bool isFlicker = true;
    [SerializeField] Light myLight;
    [SerializeField] float iStep = 1.0f, iMax = 20.0f, iMin = 5.0f;

	// Use this for initialization
	void Start () {
        myLight = this.GetComponent<Light>();
        if (myLight == null) Debug.LogError("AlarmLight.cs requires a light component.");
	}

    bool reachedIMax = false;
	void Update () {
		if (isFlicker)
        {

            if (myLight.intensity > iMax) reachedIMax = true;
            else if (myLight.intensity < iMin) reachedIMax = false;

            if (reachedIMax) myLight.intensity -= iStep;
            else myLight.intensity += iStep;
            
        }
	}
}
