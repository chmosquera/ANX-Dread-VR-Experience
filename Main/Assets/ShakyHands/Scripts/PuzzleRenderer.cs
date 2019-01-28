using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleRenderer : MonoBehaviour {

    [SerializeField] private Puzzle puzzle;
    public PuzzlePieces puzzlePiecePrefab;
    public Material startMat;
    public Material endMat;
    public Material unitMat;
    public Material powerMat;

    private float pieceWidth = 0.0f;
    private float pieceHeight = 0.0f;
    public List<PuzzlePieces> puzzlePieces;

    // Use this for initialization
    void Start () {
        pieceWidth = puzzle.transform.localScale.x / puzzle.size;
        pieceHeight = puzzle.transform.localScale.y / puzzle.size;

        print("width: " + pieceWidth + "  height: " + pieceHeight);

        // Construct pieces
        for (int i = 0; i < puzzle.size; i ++) {
            for (int j = 0; j < puzzle.size; j++) {
                PuzzlePieces p = Instantiate(puzzlePiecePrefab, new Vector3(j * pieceWidth, i * pieceHeight, 0), Quaternion.identity);
                p.gameObject.transform.SetParent(this.transform);
                p.gameObject.transform.localScale = new Vector3(pieceWidth, pieceHeight, 0.1f);
                puzzle.puzzlePieces.Add(p);
            }
        }

        puzzle.SetScenario();
        RenderPuzzle();

    }
	
	// Update is called once per frame
	void Update () {
		
       // if (puzzle.startPuzzle) {
            



        //}
	}

    public void RenderPuzzle()
    {
        foreach (PuzzlePieces p in puzzle.puzzlePieces)
        {
            PrimaryType pType = p.GetPrimaryType();
            SecondaryType sType = p.GetSecondaryType();

            MeshRenderer rend = p.gameObject.GetComponent<MeshRenderer>();
            //            Material mat2 = new Material();

            // Material
            if (sType == SecondaryType.START)
            {
                rend.material = startMat;
            }
            else if (sType == SecondaryType.END)
            {
                rend.material = endMat;
            }
            else if (sType == SecondaryType.UNIT)
            {
                rend.material = unitMat;
            }
            else if (sType == SecondaryType.POWERSOURCE)
            {
                rend.material = powerMat;
            }

            // Color
            if (pType == PrimaryType.CLOSE)
            {
                rend.material.color = Color.grey;
                print("close: " + p.gameObject.name);
            }
            else if (pType == PrimaryType.OPEN)
            {
                rend.material.color = Color.white;
                print("open: " + p.gameObject.name);
            }

            //p.gameObject.GetComponent<Renderer>().material = mat;

        }
    }
}
