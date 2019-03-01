using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitingShipState : State {

    public bool helmetGrabbed = false;

    // The base case for the constructor is evoked
    public ExitingShipState(HeartbeatHallwayManager hbManager) : base(hbManager){
        // Add more lines unique to this state's constructor
        hbManager.audioSource.clip = hbManager.endMusic;
        hbManager.audioSource.Play();
    }

    public override void Tick() {
        if (helmetGrabbed) {
            hbManager.helmet.SetActive(true);
        }
    }

    public override void OnStateEnter() {
        Debug.Log("State Entered: " + "'ExitingShipState'");
    }   

    public override void OnStateExit() {
        Debug.Log("State Exited: " + "'ExitingShipState'");
    }
}