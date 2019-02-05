using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayManager : MonoBehaviour {

    // inactive - doesn't do anything
    // enable - events will only happen once
    // active - will happen at every frame
    // disable - events will happen once then goes to inactive
    public enum hallwayStates {INACTIVE, ENABLE, ACTIVE, DISABLE}
    private hallwayStates = INACTIVE;

    public Audio SpaceMusicAudioSource;
    public GameState gameState;

    private SpaceMusicScript spaceMusic;

	// Use this for initialization
	void Start () {
        spaceMusic = SpaceMusicAudioSource.gameObject.GetComponent<SpaceMusicScript>();
	}
	
	// Update is called once per frame
	void Update () {
		switch(gameState)
        {

            case GameState.Recover:
                spaceMusic = 
                break;
            default:

                break;
        }
	}


}
