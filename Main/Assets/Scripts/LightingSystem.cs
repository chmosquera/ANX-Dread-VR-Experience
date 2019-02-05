using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CPLightState {init, startButtonPressed, crash, recover}

// Lighting system of control panel
public class LightingSystem : MonoBehaviour {

    
    public Light areaLightAboveControlPanel;
    public Light controlRoomAreaLight;
    public Light screenLight;
    public Light startButtonLight;
    public trailLightScript left1;
    public trailLightScript left2;
    public trailLightScript mid;
    public trailLightScript right1;
    public trailLightScript right2;

    // Side Screen Lights
    private float side_screenLights_count = 0f;
    private bool side_screenLights_pulseDir = true;
    public Light LSideScreenLight;
    public Light RSideScreenLight;

    public trailLightScript tool; // new to guide the user to the tool
    public Light toolLight; // new to highlight the tool

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

                SideScreenLights_Intro();
                break;
            case CPLightState.startButtonPressed:
                
                startButtonLight.color = Color.green;
                left1.useLights = false;
                left2.useLights = false;
                mid.useLights = false;
                right1.useLights = false;
                right2.useLights = false;

                if (screenLight.intensity < 2.5f)
                {
                    screenLight.intensity += Time.deltaTime * 0.5f;
                }
                break;

            case CPLightState.crash:
                SideScreenLights_Crash();
                break;
            case CPLightState.recover:
                controlRoomAreaLight.intensity = 2.5f;
                controlRoomAreaLight.color = new Color(109f / 255f, 109f / 255f, 109f / 255f, 1f);

                SideScreenLights_Recover();

                break;
            // ************************
            // need to make a state where the leading lights and tool spotlight go away after the tool is grabbed
            // ************************
        }
	}

    void SideScreenLights_Intro() {
        print("side screen lights - INTRO");
        LSideScreenLight.color = Color.white;
        RSideScreenLight.color = Color.white;

        LSideScreenLight.intensity = 2.5f;
        RSideScreenLight.intensity = 2.5f;
    }

    void SideScreenLights_Crash() {
        print("side screen lights - CRASH");
        LSideScreenLight.color = Color.red;
        RSideScreenLight.color = Color.red;

        // pulse light
        if (side_screenLights_pulseDir)
        {
            LSideScreenLight.intensity += 0.1f;
            RSideScreenLight.intensity += 0.1f;
        }
        else
        {
            LSideScreenLight.intensity -= 0.1f;
            RSideScreenLight.intensity -= 0.1f;
        }

        // change pulse direction
        if (side_screenLights_count > 1f) {
            side_screenLights_pulseDir = !side_screenLights_pulseDir;
            side_screenLights_count = 0f;
        }

        side_screenLights_count += Time.deltaTime;
    }

    void SideScreenLights_Recover() {
        print("side screen lights - RECOVER");
        LSideScreenLight.color = Color.green;
        RSideScreenLight.color = Color.green;

        LSideScreenLight.intensity = 2.5f;
        RSideScreenLight.intensity = 2.5f;
    }
}
