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

        puzzle.SetupScenario();
        RenderPuzzle();

    }
	
	// Update is called once per frame
	void Update () {
        RenderPuzzle();
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
            if (p.activated == true)
            {
                if (p.activated == false) {          // not activated
                    rend.material.color = Color.white;
                }
                else if (p.activated == true && p.value == 1)       // activated and correct
                {
                    rend.material.color = Color.green;
                }
                else if (p.activated == true && p.value == 0)                      // activated and incorrect
                {
                    rend.material.color = Color.red;
                }
            }

            //p.gameObject.GetComponent<Renderer>().material = mat;

        }
    }
}
