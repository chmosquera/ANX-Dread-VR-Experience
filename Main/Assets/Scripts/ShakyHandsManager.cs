using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakyHandsManager : MonoBehaviour {

    [Header("Manager Objects")]
    public GameManager gameManager;
    public GameState gameState;

    [Header("Door Objects")]
    public FirstDoor door;
    public AlarmLight alarm;

    [Header("Puzzle Objects")]
    public GameObject puzzleObject;
    public Puzzle puzzle;
    
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        // get door state from doorObj and send to other objects that depend on it. 
        alarm.doorState = door.state;

		switch (gameState)
        {
            case GameState.Intro:
                puzzleObject.SetActive(false);
                break;
            case GameState.Crash:
                puzzleObject.SetActive(true);
                break;
            case GameState.Recover:
                puzzleObject.SetActive(true);
                door.InitiateBroken();

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
