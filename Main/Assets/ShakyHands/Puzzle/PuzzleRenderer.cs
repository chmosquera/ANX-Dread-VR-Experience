﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleRenderer : MonoBehaviour {

    [SerializeField] private Puzzle puzzle;
    public PuzzlePieces puzzlePiecePrefab;
    public Material startMat;
    public Material endMat;
    public Material unitMat;
    public Material powerMat;
    public Collider touchingObj;
    public MeshRenderer frameRender;

    private float redFlash = 0.5f;
    private int state = 0;
    private float blink_timer = 1.0f;
    private bool blink_switch = true;

    private float pieceWidth = 0.0f;
    private float pieceHeight = 0.0f;

    // Use this for initialization
    void Start () {
        pieceWidth = puzzle.transform.localScale.x / puzzle.size;
        pieceHeight = puzzle.transform.localScale.y / puzzle.size;

        print("width: " + pieceWidth + "  height: " + pieceHeight);

        // Construct empty puzzle
        GameObject boardObj = new GameObject();
        boardObj.name = "PuzzleBoard";
        boardObj.transform.SetParent(this.transform);

        // Construct pieces to put into puzzle
        for (int i = 0; i < puzzle.size; i ++) {
            for (int j = 0; j < puzzle.size; j++) {
                // PuzzlePieces p = Instantiate(puzzlePiecePrefab, new Vector3(j * pieceWidth, i * pieceHeight, 0) + this.transform.position, Quaternion.identity);
                PuzzlePieces p = Instantiate(puzzlePiecePrefab);           
                p.gameObject.transform.SetParent(boardObj.transform);
                p.transform.localPosition = new Vector3(j * pieceWidth, i * pieceHeight, 0);
                p.gameObject.transform.localScale = new Vector3(pieceWidth, pieceHeight, 0.1f);
                p.touchingObj = this.touchingObj;
                puzzle.puzzlePieces.Add(p);
            }
        }

        boardObj.transform.position = this.transform.position;
        boardObj.transform.rotation = this.transform.rotation;

        puzzle.SetupScenario();
        RenderPuzzle();

    }
	
	// Update is called once per frame
	void Update () {

        switch (puzzle.state)
        {
            case PuzzleState.INIT:

                frameRender.material.SetColor("_EmissionColor", Color.grey);

                // Starting tile, blink green.
                if (puzzle.blinkStart)
                {
                    if (blink_timer <= 0.0f)
                    {
                        if (blink_switch)
                        {
                            puzzle.pieceStart.gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.white);
                        }
                        else
                        {
                            puzzle.pieceStart.gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.green);
                        }
                        blink_switch = !blink_switch;
                        blink_timer = 1.0f;
                    }

                    blink_timer -= Time.deltaTime;
                }
                break;

            case PuzzleState.UNSOLVED:
                frameRender.material.SetColor("_EmissionColor", Color.white);
                RenderPuzzle();
                break;
            case PuzzleState.SOLVED:
                frameRender.material.SetColor("_EmissionColor", Color.green);
                for (int i = 0; i < puzzle.puzzlePieces.Count; i++) {
                    if (puzzle.solution[i] == 1) {
                        puzzle.puzzlePieces[i].gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.green);                  
                    }
                }
                break;
            case PuzzleState.ERROR:
                frameRender.material.SetColor("_EmissionColor", Color.red);
                break;
        }
    }

    public void RenderPuzzle()
    {

        foreach (PuzzlePieces p in puzzle.puzzlePieces)
        {
            PieceType sType = p.GetType();

            MeshRenderer rend = p.gameObject.GetComponent<MeshRenderer>();
            //            Material mat2 = new Material();

            // Material
            if (sType == PieceType.START)
            {
                rend.material = startMat;
            }
            else if (sType == PieceType.END)
            {
                rend.material = endMat;
            }
            else if (sType == PieceType.UNIT)
            {
                rend.material = unitMat;
            }

            // Color
            if (p.activated == false) {          // not activated
                //rend.material.color = Color.white;
                rend.material.SetColor("_EmissionColor", Color.white);
            }
            else if (p.activated == true && p.value == 1)       // activated and correct
            {
                //rend.material.color = Color.green;
                rend.material.SetColor("_EmissionColor", Color.green);
            }
            else if (p.activated == true && p.value == 0)                      // activated and incorrect
            {
                //rend.material.color = Color.red;
                rend.material.SetColor("_EmissionColor", Color.red);
                //FlashRedPiece(rend);
                puzzle.redHit = true;
            }
            //else
            //{
            //    redFlash = 0.5f;
            //}
            

            //p.gameObject.GetComponent<Renderer>().material = mat;

        }
    }

    //public void FlashRedPiece(MeshRenderer rend)        // red flashing task made to make it look better when you fail the puzzle
    //{
    //    if (state == 0)
    //    {
    //        redFlash -= Time.deltaTime;
    //        if (redFlash > 0)
    //        {
    //            rend.material.color = Color.red;
    //        }
    //        else
    //        {
    //            state = 1;
    //        }

    //    }
    //    else
    //    {
    //        redFlash += Time.deltaTime;
    //        if (redFlash < 0.5f)
    //        {
    //            rend.material.color = Color.white;
    //        }
    //        else
    //        {
    //            state = 0;
    //        }
    //    }
    //}
}