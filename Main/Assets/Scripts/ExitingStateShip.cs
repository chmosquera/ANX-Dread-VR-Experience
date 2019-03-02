using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ExitingShipState : State {

    public bool helmetGrabbed = false;

    private VRTK_InteractableObject helmetInteractable;

    // The base case for the constructor is evoked
    public ExitingShipState(HeartbeatHallwayManager hbManager) : base(hbManager){

        name = "ExitingShipState";

        hbManager.audioSource.clip = hbManager.endMusic;
        hbManager.audioSource.Play();

        if ((helmetInteractable = hbManager.helmet.GetComponent<VRTK_InteractableObject>()) != null)
            Debug.LogError("<ExitingStateShip> Trying to interact with an object that requires the component VRTK_InteractableObject");
    }

    public override void Tick() {
        if (hbManager.helmet.GetComponent<VRTK_InteractableObject>().IsGrabbed() &&
            hbManager.helmet.GetComponent<SpaceHelmet>().wearableObjHit == true)
        {
            Debug.Log("helmet can be put on");
        }


    }

    public override void OnStateEnter() {
        Debug.Log("State Entered: " + "'ExitingShipState'");
    }   

    public override void OnStateExit() {
        Debug.Log("State Exited: " + "'ExitingShipState'");
    }
}