using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PuzzleState {INIT, UNSOLVED, SOLVED, ERROR};

public class Puzzle : MonoBehaviour {

    public int size = 5;
    public PuzzleState state = PuzzleState.INIT;
    public List<PuzzlePieces> puzzlePieces;

    public PuzzlePieces pieceStart;
    public PuzzlePieces pieceEnd;

    public bool endPuzzle = false;
    public bool startPuzzle = false;
    public bool redHit = false;
    public bool blinkStart = false;

    private float waitRestart = 1.5f;

    public int[] solution = new int[]  {1, 1, 0, 0, 0,
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
        switch (state) {
            case PuzzleState.INIT:
                blinkStart = true;

                if (startPuzzle) {
                    state = PuzzleState.UNSOLVED;
                    blinkStart = false;
                }
                break;
            case PuzzleState.UNSOLVED:
                if (startPuzzle)
                {
                    if (!redHit)
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
                                print("unsolved");
                                // restart puzzle
                                RestartPuzzle();

                            }
                        }
                    }
                    else
                    {
                        state = PuzzleState.ERROR;
                    }
                }
                else
                {
                    RestartPuzzle();
                }
                break;

            case PuzzleState.ERROR:
                RestartPuzzle();
                break;
            case PuzzleState.SOLVED:
                
                break;
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

    public void RestartPuzzle()
    {
        if (waitRestart > 0)
        {
            waitRestart -= Time.deltaTime;
        }
        else
        {
            waitRestart = 1.5f;
            foreach (PuzzlePieces p in puzzlePieces)
            {
                p.activated = false;
            }

            endPuzzle = false;
            startPuzzle = false;
            redHit = false;

            state = PuzzleState.UNSOLVED;
        }
    }
}
