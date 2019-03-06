using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SH;

public class WalkingThroughState : State {



    // The base case for the constructor is evoked
    public WalkingThroughState(HeartbeatHallwayManager hbManager) : base(hbManager){

        hbManager.state = Hallway2State.WalkingThroughState;

        hbManager.audioSource.clip = hbManager.hallwayMusic;
        hbManager.audioSource.Play();
    }

    public override void Tick() {
        if (hbManager.doorObj.doorstate == hsDoorState.scanning) hbManager.SetState(new ScanningState(hbManager));
    }

    public override void OnStateEnter() {
        Debug.Log("State Entered: " + "'WalkingThroughState'");
    }   

    public override void OnStateExit() {
        Debug.Log("State Exited: " + "'WalkingThroughState'");
    }
}