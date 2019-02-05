using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakyHandsManager : MonoBehaviour {

    public GameState gameState;
    public FirstDoor door;
    public Puzzle puzzle;

    public AlarmLight alarm;
    public bool playMusic = false;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        // get door state from doorObj and send to other objects that depend on it. 
        alarm.doorState = door.state;

		switch (gameState)
        {
            case GameState.Intro:
                break;
            case GameState.Crash:
                break;
            case GameState.Recover:

//                door.InitiateBroken();
 //               print("puzzle state: " + puzzle.state);
            
                if (puzzle.state == PuzzleState.SOLVED) {
                    print("opening door");
                    door.state = DoorState.opening;
                    playMusic = true;
                } else if (puzzle.state == PuzzleState.UNSOLVED)
                {
                    print("breaking door");
                    door.state = DoorState.broken;
                }
                //door.state = DoorState.broken;
                //alarm.doorState = DoorState.broken;

                break;
        }

	}
}
