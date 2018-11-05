using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    public Rigidbody doorLeft;
    public Rigidbody doorRight;
    [SerializeField] private float stepScale = 0.5f;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
        if (Input.GetKey(KeyCode.UpArrow)) {            // Open doors
            doorLeft.MovePosition(doorLeft.position + new Vector3(stepScale, 0, 0));
            doorLeft.transform.veloc
            doorRight.MovePosition(doorRight.position + new Vector3(-stepScale, 0, 0));
        } else if (Input.GetKey(KeyCode.DownArrow)) {   // Close doors
            doorLeft.MovePosition(doorLeft.position + new Vector3(-stepScale, 0, 0));
            doorRight.MovePosition(doorRight.position + new Vector3(stepScale, 0, 0));
        }

	}
}
