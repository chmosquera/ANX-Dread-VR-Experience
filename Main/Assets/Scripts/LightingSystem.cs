using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CPLightState {init, startButtonPressed, shipCrashes, recover}

public class LightingSystem : MonoBehaviour {

    public List<Light> lights;
    public GameManager gameManager;
    public CPLightState state = CPLightState.init;

    public bool startButtonPressed = false;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		switch(state)
        {
            case CPLightState.startButtonPressed:
                lights[1].intensity = 2.5f;
                lights[1].color = new Color(152f/255f, 149f/255f, 137f/255f, 1f);
                break;
            case CPLightState.recover:
                lights[1].intensity = 2.5f;
                lights[1].color = new Color(109f / 255f, 109f / 255f, 109f / 255f, 1f);

                //StartCoroutine(Flashing(lights[0], 4.5f, 6.5f, 0.1f));
                break;
        }
	}

    //IEnumerator Flashing(Light light, float min, float max, float step)
    //{
    //    if (light.Intensity < min)
    //    light.Intensity = lightIntensity + step;
    //}


}
