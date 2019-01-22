using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanelManager : MonoBehaviour {

    public OpenScreenScript startButton;
    public GameObject screen;
    public GameState gameState;
    public LightingSystem lightSystem;
    public GameManager manager;
    public FocusSphere fadeOutSphere;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        switch (gameState)
        {
            case GameState.Intro:
                if (startButton.screenActive)
                {
                    screen.SetActive(true);
                    lightSystem.startButtonPressed = true;

                    // for now, going to recover state. Later, must first go to crash state
                    manager.ChangeGameState(GameState.Recover);
                }
              
                break;
            case GameState.Crash:
                // This event occurs during intro setup

                break;
            case GameState.Recover:
                fadeOutSphere.fadeActive = true;


                break;
        }
	}

}

