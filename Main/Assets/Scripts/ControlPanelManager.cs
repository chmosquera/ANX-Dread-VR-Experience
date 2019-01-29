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

    // Use this for initialization
    void Start () {
        screen.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        switch (gameState)
        {
            case GameState.Intro:
                if (startButton.screenActive)
                {
                    screen.SetActive(true);
                    //lightSystem.startButtonPressed = true;
                    lightSystem.state = CPLightState.startButtonPressed;
                    
                    if (Input.GetKey(KeyCode.B)) {
                        begin.SetActive(true);
                        character.SetActive(false);
                        attributes.SetActive(false);
                        print("Button 'B' pressed - Begin Image set to Active?");
                    }
                    if (Input.GetKey(KeyCode.N))
                    {
                        begin.SetActive(false);
                        character.SetActive(true);
                        attributes.SetActive(false);
                        print("Button 'N' pressed - Character Image set to Active?");
                    }
                    if (Input.GetKey(KeyCode.M))
                    {
                        begin.SetActive(false);
                        character.SetActive(false);
                        attributes.SetActive(true);
                        print("Button 'M' pressed - Attributes Image set to Active?");
                    }
                    if (Input.GetKey(KeyCode.C))
                    {
                        // for now, going to recover state. Later, must first go to crash state
                        print("Button 'C' pressed - GameState Switching to Recover?");
                        manager.ChangeGameState(GameState.Recover);
                    }
             
                } 
                break;

            case GameState.Crash:
                // This event occurs during intro setup
                
                break;
            case GameState.Recover:
                fadeOutSphere.fadeActive = true;
                fadeOutSphere.gameObject.SetActive(false);


                break;
        }
	}

}

