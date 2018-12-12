using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SH;

public enum Scene { Intro, ShakyHands, Hallway }

public class GameManager : MonoBehaviour {

    public OpenScreenScript openScreenBtn;
    public GameObject SH_Door;
    public Scene sceneState;
    public FocusSphere fadeOutSphere;
    public Light CR_areaLight;

    // Use this for initialization
    void Start () {
        sceneState = Scene.Intro;
	}
	
	// Update is called once per frame
	void Update () {

        // trigger a scene state transition
        if (openScreenBtn.screenActive == true) sceneState = Scene.ShakyHands;

        // update according to scenestate
            switch (sceneState) {
            case Scene.Intro:
                SH_Door.GetComponentInChildren<door>().doorstate = SH.DoorState.closed;
                CR_areaLight.intensity = 0.1f;
                break;
            case Scene.ShakyHands:
                fadeOutSphere.fadeActive = true;
                //SH_Door.GetComponentInChildren<door>().doorstate = SH.DoorState.broken;
                SH_Door.GetComponentInChildren<door>().SetBroken();
                if (CR_areaLight.intensity < 1.0f) {
                    CR_areaLight.intensity += 0.01f;
                }
                break;

        }        
	}
}
