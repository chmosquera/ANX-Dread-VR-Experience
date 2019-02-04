using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanelManager : MonoBehaviour {

    public OpenScreenScript startButton;
    public GameObject screen;
    public GameObject begin;
    public GameObject character;
    public GameObject attributes;
    public GameState gameState;
    public LightingSystem lightSystem;
    public GameManager manager;
    public FocusSphere fadeOutSphere;
    private static float crashCountdown = 3f;
    private int flashCount = 0;
    private bool flag = false;

    // Use this for initialization
    void Start () {
        screen.SetActive(true);
        begin.SetActive(true);
        character.SetActive(false);
        attributes.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        switch (gameState)
        {
            case GameState.Intro:

                if (startButton.screenActive) {

                    lightSystem.state = CPLightState.startButtonPressed;
                    begin.SetActive(false);
                    character.SetActive(true);
                    attributes.SetActive(false);
                    print("Press V to go to Attributes screen");
                    if (Input.GetKey(KeyCode.V))
                    {
                        begin.SetActive(false);
                        character.SetActive(false);
                        attributes.SetActive(true);
                        print("Button 'V' pressed - Attributes Image set to Active?");

                        manager.ChangeGameState(GameState.Crash);
                    }
             
                } 
                break;

            case GameState.Crash:
                lightSystem.state = CPLightState.crash;
                CrashInitiate();

                break;
            case GameState.Recover:
                lightSystem.state = CPLightState.recover;
                fadeOutSphere.fadeActive = true;
                fadeOutSphere.gameObject.SetActive(false);


                break;
        }
	}


    private void CrashInitiate(){
        
        print("changing to crash scene");
        if (crashCountdown > 0)
        {
            crashCountdown -= Time.deltaTime;
            flashCount++;
            if (flashCount >= 20)
            {
                screen.SetActive(flag);
                flag = !flag;
                flashCount = 0;
            }
        }
        else
        {
            screen.SetActive(false);
            manager.ChangeGameState(GameState.Recover);
            print("changing to recover scene");
        }
    }
}

