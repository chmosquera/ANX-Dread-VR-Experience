using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanelManager : MonoBehaviour {

    // Game Manager stuff
    [Header("Manager Objects")]
    public GameManager manager;
    public GameState gameState;

    [Header("Control Panel Objects")]
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

    [Header("Audio Objects")]
    public AudioSource controlpanelAudioSource;
    public AudioClip crash_sound;
    public AudioClip background_sound;

    [Header("Other Objects")]
    public LightingSystem lightSystem;
    public FocusSphere fadeOutSphere;
    public OpenScreenScript startButton;


    // Local variables
    private static float crashCountdown = 5f;
    private int flashCount = -200;
    private bool flag = false;
    private bool charSelect = false;
    private bool initCrash = false;
    private bool initRecover = false;

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


                } 
                break;

            case GameState.Crash:
                if (initCrash == false)
                {
                    controlpanelAudioSource.clip = crash_sound;
                    controlpanelAudioSource.Play();
                    
                    lightSystem.state = CPLightState.crash;
                    ActivateSystemErrorMsg();

                    initCrash = true;
                }
                
                GlobalCountDown.StartCountDown(TimeSpan.FromMinutes(5));

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
                if (initRecover == false)
                {
                    controlpanelAudioSource.clip = background_sound;
                    controlpanelAudioSource.Play();                   

                    DeactivateAllScreens();
                    ActivateAutomaticRecoveryMsg();

                    lightSystem.state = CPLightState.recover;
                    fadeOutSphere.fadeActive = true;
                    fadeOutSphere.gameObject.SetActive(false);

                    initRecover = true;
                }


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

