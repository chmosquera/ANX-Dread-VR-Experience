using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorText : MonoBehaviour {

    public Rigidbody scanner;
    public Vector3 move;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 v = scanner.position + move;
        transform.position = v; 
	}
}
