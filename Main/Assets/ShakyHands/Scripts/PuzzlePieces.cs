using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PieceType {START, END, UNIT};

public class PuzzlePieces : MonoBehaviour {

    public int value = 0;
    public Puzzle puzzle;
    public bool activated = false;

    [SerializeField] private PieceType sType = PieceType.UNIT;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public PieceType GetType()
    {
        return sType;
    }

    #region Types
    public void SetStart() {
        sType = PieceType.START;
    }

    public void SetEnd()
    {
        sType = PieceType.END;
    }

    public void SetUnit()
    {
        sType = PieceType.UNIT;
    }
    #endregion

    #region Triggers
    void OnTriggerEnter(Collider other) {
        if (other.GetComponent<PuzzlePieces>() != null) return; // don't accept collisions with each other

        print("entered: " + this.gameObject.name);
        activated = !activated;

        if (sType == PieceType.START && activated)
        {
            puzzle.startPuzzle = true;
        }
        else if (sType == PieceType.START && !activated)
        {
            puzzle.startPuzzle = false;
        }

        if (sType == PieceType.END) {
            print("this is the last piece");
            puzzle.endPuzzle = true;
        }
    }
    #endregion
}
