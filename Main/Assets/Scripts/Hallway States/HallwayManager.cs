using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayManager : MonoBehaviour {

	public GameManager gameManager;
	public GameState gameState;

    // inactive - doesn't do anything
    // enable - events will only happen once
    // active - will happen at every frame
    // disable - events will happen once then goes to inactive
    public enum HallwayState {INACTIVE, ENABLE, ACTIVE, DISABLE}
	public HallwayState localState = HallwayState.INACTIVE;

    [Header("Audio Objects")]
    public AudioSource hallwayAudioSource;
    public AudioSource SpaceMusicAudioSource;
    private SpaceMusicScript spaceMusic;

	// Use this for initialization
	void Start () {
        spaceMusic = SpaceMusicAudioSource.gameObject.GetComponent<SpaceMusicScript>();
	}
	
	// Update is called once per frame
	void Update () {

		if (gameState == GameState.Recover) {

			switch(localState) {
			case HallwayState.INACTIVE:

				break;
			case HallwayState.ENABLE:
                    spaceMusic.PlayMusic();

				localState = HallwayState.ACTIVE;
				break;

			case HallwayState.ACTIVE:

				break;
			case HallwayState.DISABLE:
				// events before disabling
				spaceMusic.playMusic = false;

				localState = HallwayState.INACTIVE;
				break;
			default:

				break;
			}

		}
			
	}

    // Enables only when inactive
    public void Enable() {
        if (this.localState == HallwayState.INACTIVE) { 
            this.localState = HallwayState.ENABLE;
        }

    }

    // Disables only when active
    public void Disable()
    {
        if (this.localState == HallwayState.ACTIVE)
        {
            this.localState = HallwayState.DISABLE;
        }
    }
}
