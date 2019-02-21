﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PieceType {START, END, UNIT};

public class PuzzlePieces : MonoBehaviour {

    public int value = 0;
    public Puzzle puzzle;
    public bool activated = false;

    // The object that can interact with the puzzle pieces
    public Collider touchingObj;


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
        //if (other.GetComponent<PuzzlePieces>() != null) return; // don't accept collisions with each other
        if (other != touchingObj) return;
        print("piece triggered");
        
     
        if (sType != PieceType.START && !puzzle.startPuzzle) return;
        print("piece should change color triggered");

        activated = true;
        
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