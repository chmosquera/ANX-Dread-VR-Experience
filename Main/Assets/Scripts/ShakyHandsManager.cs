using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakyHandsManager : MonoBehaviour {

    public GameManager gameManager;
    public GameState gameState;
    public FirstDoor door;
    public Puzzle puzzle;

    public AlarmLight alarm;
    
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
            
                if (puzzle.state == PuzzleState.SOLVED) {
                    gameManager.EnableHallwayManager();
                    door.state = DoorState.opening;
                } else if (puzzle.state == PuzzleState.UNSOLVED)
                {
                    door.state = DoorState.broken;
                }

                break;
        }

	}
}
