using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SH;

public enum Hallway2State {WalkingThroughState, ScanningState, ExitingShipState};

public class HeartbeatHallwayManager : MonoBehaviour
{

    [Header("Objects used by states")]
    public hsDoor doorObj;
    public AudioSource audioSource;
    public AudioClip endMusic;
    public AudioClip hallwayMusic;

    public GameObject VRTK_SDKManager;
    public GameObject SteamVR;
    public GameObject VRSimulator;
    public Rigidbody playerRB;

    [Header("General Settings")]
    public Hallway2State state;

    private State currentState;

    void Start()
    {
        //print("--------------------" + VRTK_SDKManager.GetComponentInChildren<Hallway_Zoom>().name);
        //player = VRTK_SDKManager.GetComponentsInChildren(typeof(Hallway_Zoom), false)[0].GetComponent<Rigidbody>();
        
        SetState(new WalkingThroughState(this));
    }

    void Update()
    {
        if (VRSimulator.activeSelf) {
            playerRB = VRSimulator.GetComponentInChildren<Hallway_Zoom>().GetComponent<Rigidbody>();
            print ("--------" + playerRB.name);
        } else if (SteamVR.activeSelf) {
            playerRB = SteamVR.GetComponentInChildren<Hallway_Zoom>().GetComponent<Rigidbody>();
            print ("--------" + playerRB.name);
        }        
        if (currentState != null) currentState.Tick();
    }

    public void SetState(State state)
    {
        if (currentState == state) return;  

        if (currentState != null) currentState.OnStateExit();
        currentState = state;
        if (currentState != null) currentState.OnStateEnter();
    }

}
