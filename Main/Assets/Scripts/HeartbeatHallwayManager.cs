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

    [Header("General Settings")]
    public Hallway2State state;

    private State currentState;

    void Start()
    {
        SetState(new WalkingThroughState(this));
    }

    void Update()
    {
        currentState.Tick();
    }

    public void SetState(State state)
    {
        if (currentState == state) return;  

        if (currentState != null) currentState.OnStateExit();
        currentState = state;
        if (currentState != null) currentState.OnStateEnter();
    }

}
