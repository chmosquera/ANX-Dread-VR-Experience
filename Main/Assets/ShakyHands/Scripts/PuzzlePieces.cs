using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PrimaryType { OPEN, CLOSE };
public enum SecondaryType { POWERSOURCE, START, END, UNIT, EMPTY};

public class PuzzlePieces : MonoBehaviour {

    public int voltage = 0;
    public int minV = 1;
    public int maxV = 5;

    [SerializeField] private PrimaryType pType = PrimaryType.CLOSE;
    [SerializeField] private SecondaryType sType = SecondaryType.UNIT;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public PrimaryType GetPrimaryType() {
        return pType;
    }

    public SecondaryType GetSecondaryType()
    {
        return sType;
    }

    public void SetStart() {
        pType = PrimaryType.CLOSE;
        sType = SecondaryType.START;
    }

    public void SetEnd()
    {
        pType = PrimaryType.CLOSE;
        sType = SecondaryType.END;
    }

    public void SetClosedUnit()
    {
        pType = PrimaryType.CLOSE;
        sType = SecondaryType.UNIT;
    }

    public void SetOpenedUnit()
    {
        pType = PrimaryType.OPEN;
        sType = SecondaryType.UNIT;
    }

    public void SetClosedPower()
    {
        pType = PrimaryType.CLOSE;
        sType = SecondaryType.POWERSOURCE;
    }

    public void SetOpenedPower()
    {
        pType = PrimaryType.OPEN;
        sType = SecondaryType.POWERSOURCE;
    }

    public void SetClosedEmpty()
    {
        pType = PrimaryType.CLOSE;
        sType = SecondaryType.EMPTY;
    }

    public void SetOpenedEmpty()
    {
        pType = PrimaryType.OPEN;
        sType = SecondaryType.EMPTY;
    }
}
