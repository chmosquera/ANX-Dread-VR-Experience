using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ExitingShipState : State {

    // The base case for the constructor is evoked
    public ExitingShipState(HeartbeatHallwayManager hbManager) : base(hbManager){

        hbManager.state = Hallway2State.ExitingShipState;

        hbManager.audioSource.clip = hbManager.endMusic;
        hbManager.audioSource.Play();   
    }

    public override void Tick() {



    }

    public override void OnStateEnter() {
        Debug.Log("State Entered: " + "'ExitingShipState'");

        // change effects of gravity
        hbManager.playerRB.drag = 5f;
        hbManager.playerRB.mass = 1f;
    }   

    public override void OnStateExit() {
        Debug.Log("State Exited: " + "'ExitingShipState'");
    }
}