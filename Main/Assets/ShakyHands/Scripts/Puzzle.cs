using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PuzzleState {UNSOLVED, SOLVED};

public class Puzzle : MonoBehaviour {

    public int size = 5;
    public PuzzleState state = PuzzleState.UNSOLVED;
    public List<PuzzlePieces> puzzlePieces;
    public bool startPuzzle = false;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (this.IsSolved()) {

        }
    }

    private bool IsSolved()
    {
        int sum = 0;

        //for (int i = 0; i < size; i++)
        //{
        //    for (int j = 0; j < size; j++)
        //    {
        //        sum += puzzlePieces[i,j].voltage;
        //    }

        //}

        if (sum == 0) return true;
        return false;
    }

    public void SetScenario() {
        for (int i = 0; i < size; i++) {
            for (int j = 0; j < size; j++)     {

                int idx = (i * size) + j;

                if (i%2==0) {
                    if (j % 2 == 0)
                    {
                        puzzlePieces[idx].SetClosedUnit();
                    }
                    else
                    {
                        puzzlePieces[idx].SetOpenedUnit();
                    }
                }
                else
                {                    
                    puzzlePieces[idx].SetOpenedUnit();
                }

            }
        }

        puzzlePieces[0].SetStart();
        puzzlePieces[puzzlePieces.Count - 1].SetEnd();


        startPuzzle = true;
    }
}
