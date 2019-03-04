using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SH;

public class ScanningState : State {

    // The base case for the constructor is evoked
    public ScanningState(HeartbeatHallwayManager hbManager) : base(hbManager){
        // Add more lines unique to this state's constructor
    }

    public override void Tick() {
        if (!(hbManager.doorObj.doorstate == hsDoorState.locked) && !(hbManager.doorObj.doorstate == hsDoorState.scanning))
            hbManager.SetState(new ExitingShipState(hbManager));

        hbManager.state = Hallway2State.ScanningState;
    }

    public override void OnStateEnter() {
        Debug.Log("State Entered: " + "'ScanningState'");
    }   

    public override void OnStateExit() {
        Debug.Log("State Exited: " + "'ScanningState'");
    }
}