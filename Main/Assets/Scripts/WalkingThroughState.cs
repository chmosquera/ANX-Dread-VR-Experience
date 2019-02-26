using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingThroughState : State {

    // The base case for the constructor is evoked
    public WalkingThroughState(HeartbeatHallwayManager hbManager) : base(hbManager){
        // Add more lines unique to this state's constructor
    }

    public override void Tick() {
        
    }

    public override void OnStateEnter() {
        Debug.Log("State Entered: " + "'WalkingThroughState'");
    }   

    public override void OnStateExit() {
        Debug.Log("State Exited: " + "'WalkingThroughState'");
    }
}