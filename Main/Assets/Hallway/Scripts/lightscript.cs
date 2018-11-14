using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightscript : MonoBehaviour {

    Light myLight;

	// Use this for initialization
	void Start () {
        myLight = this.gameObject.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        myLight.intensity += 0.1f;
	}
}
