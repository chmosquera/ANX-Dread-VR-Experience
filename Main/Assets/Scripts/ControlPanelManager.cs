using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanelManager : MonoBehaviour {

    // Game Manager stuff
    public GameManager manager;
    public GameState gameState;
    public LightingSystem lightSystem;
    public FocusSphere fadeOutSphere;
    public OpenScreenScript startButton;

    // Control Panel Screen
    public CharSelectScript tomSelectScript;
    public CharSelectScript zarinaSelectScript;
    public CharSelectScript haramSelectScript;
    public GameObject screen;
    public GameObject begin;
    public GameObject character;
    public GameObject attributes;
    public GameObject selTom;
    public GameObject selFairy;
    public GameObject selHaram;
    public GameObject blackScreen;
    public GameObject systemError;
    public GameObject automaticRecovery;
    public GameObject puzzleGame;

    // Local variables
    private static float crashCountdown = 5f;
    private int flashCount = -200;
    private bool flag = false;
    private bool charSelect = false;

    // Use this for initialization
    void Start () {
        screen.SetActive(true);
        begin.SetActive(true);
        character.SetActive(false);
        attributes.SetActive(false);
        selTom.SetActive(false);
        selFairy.SetActive(false);
        selHaram.SetActive(false);
        //blackScreen.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        switch (gameState)
        {
            case GameState.Intro:
                DeactivateAllMsgs();

                if (startButton.screenActive) {

                    lightSystem.state = CPLightState.startButtonPressed;
                    begin.SetActive(false);
                    character.SetActive(true);
                    attributes.SetActive(false);
                    selTom.SetActive(true);
                    selFairy.SetActive(true);
                    selHaram.SetActive(true);
                    //blackScreen.SetActive(false);

                    if (tomSelectScript.charSelect || zarinaSelectScript.charSelect || haramSelectScript.charSelect)
                    {
                        selTom.SetActive(false);
                        selFairy.SetActive(false);
                        selHaram.SetActive(false);
                        character.SetActive(false);
                        attributes.SetActive(true);
                        //blackScreen.SetActive(false);

                        manager.ChangeGameState(GameState.Crash);
                    }

                    puzzleGame.SetActive(false);

                } 
                break;

            case GameState.Crash:
                lightSystem.state = CPLightState.crash;
                ActivateSystemErrorMsg();
                puzzleGame.SetActive(true);

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

                break;
            case GameState.Recover:
                puzzleGame.SetActive(true);
                DeactivateAllScreens();
                ActivateAutomaticRecoveryMsg();

                lightSystem.state = CPLightState.recover;
                fadeOutSphere.fadeActive = true;
                fadeOutSphere.gameObject.SetActive(false);


                break;
        }
	}

    void DeactivateAllScreens() {
        selTom.SetActive(false);
        selFairy.SetActive(false);
        selHaram.SetActive(false);
        character.SetActive(false);
        attributes.SetActive(false);
        //blackScreen.SetActive(true);
    }

    void ActivateSystemErrorMsg() {
        systemError.SetActive(true);
        automaticRecovery.SetActive(false);
    }

    void ActivateAutomaticRecoveryMsg()
    {
        systemError.SetActive(false);
        automaticRecovery.SetActive(true);
    }

    void DeactivateAllMsgs() {
        systemError.SetActive(false);
        automaticRecovery.SetActive(false);
    }
}

