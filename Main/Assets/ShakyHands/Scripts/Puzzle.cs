using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PuzzleState {UNSOLVED, SOLVED};

public class Puzzle : MonoBehaviour {

    public int size = 5;
    public PuzzleState state = PuzzleState.UNSOLVED;
    public List<PuzzlePieces> puzzlePieces;

    public PuzzlePieces pieceStart;
    public PuzzlePieces pieceEnd;

    public bool endPuzzle = false;
    public bool startPuzzle = false;
    public int[] solution = new int[] {1, 1, 0, 0, 0,
                    0, 1, 1, 1, 0,
                    0, 0, 0, 1, 0,
                    0, 0, 0, 1, 0,
                    0, 0, 0, 1, 1 };


    // Use this for initialization
    void Start () {
	}

    // Update is called once per frame
    void Update()
    {
        if (endPuzzle == true)
        {
            print("We are checking the solution");
            if (CheckSolution())
            {
                state = PuzzleState.SOLVED;
                print("solved");
            }
            else
            {
                print("unsoolved");
                // restart puzzle
            }
        }
    }

    // if this piece's activated status matches the solution
    public bool IsValid(PuzzlePieces p)
    {
        if (p.activated == false && p.value == 1) return false;
        else if (p.activated == true && p.value == 0) return false;

        return true;
    }

    public void SetupScenario() {
        // Set values of each piece
        for (int i = 0; i < puzzlePieces.Count; i++)
        {
            puzzlePieces[i].value = solution[i];
            puzzlePieces[i].SetUnit();
            puzzlePieces[i].puzzle = this;
        }

        // Set start and end of puzzle
        pieceStart = puzzlePieces[0];
        pieceStart.SetStart();
        pieceEnd = puzzlePieces[puzzlePieces.Count - 1];
        pieceEnd.SetEnd();
    }

    public bool CheckSolution()
    {
        foreach (PuzzlePieces p in puzzlePieces) {
            if (IsValid(p) == false) {
                return false;
            }
        }

        return true;
    }
}
