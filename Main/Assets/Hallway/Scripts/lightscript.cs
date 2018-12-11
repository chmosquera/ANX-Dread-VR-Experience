using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightscript : MonoBehaviour {

    Light myLight;
    int wait = 0;
    int state = 0;
    int count = 0;

	// Use this for initialization
	void Start () {
        myLight = this.gameObject.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        if (wait <= 0)
        {
            myLight.intensity += 0.1f;
            if (myLight.intensity >= 7.0f && state == 0)
            {
                myLight.intensity = 0;
                wait = 100;
                state = 1;
            }
            if (myLight.intensity >= 3.0f && state == 1)
            {
                myLight.intensity = 0;
                wait = 100;
                count++;
                if (count >= 2)
                {
                    count = 0;
                    state = 0;
                }
            }
        }
        wait--;
    }
}
