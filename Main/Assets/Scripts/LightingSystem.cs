using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CPLightState {init, startButtonPressed, crash, recover}

public class LightingSystem : MonoBehaviour {

    //public List<Light> lights;
    public Light areaLightAboveControlPanel;
    public Light controlRoomAreaLight;
    public Light screenLight;
    public Light startButtonLight;
    public GameManager gameManager;
    public CPLightState state = CPLightState.init;
    //private bool incrScreenLight = true;

    //public bool startButtonPressed = false;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		switch(state)
        {
            case CPLightState.init:
                controlRoomAreaLight.intensity = 0.0f;
                startButtonLight.color = Color.yellow;
                print(startButtonLight.color);
                break;
            case CPLightState.startButtonPressed:
                startButtonLight.color = Color.green;
                //lights[1].intensity = 2.5f;
                //lights[1].color = new Color(152f/255f, 149f/255f, 137f/255f, 1f);

                if (screenLight.intensity < 2.5f)
                {
                    screenLight.intensity += Time.deltaTime * 0.5f;
                }
                break;
            case CPLightState.recover:
                controlRoomAreaLight.intensity = 2.5f;
                controlRoomAreaLight.color = new Color(109f / 255f, 109f / 255f, 109f / 255f, 1f);

                break;
        }
	}


}
