using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    public Rigidbody doorLeft;
    public Rigidbody doorRight;
    [SerializeField] private float stepScale = 0.01f;
    [SerializeField] private float force = 8.0f;
    public ForceMode fMode;


    // Use this for initialization
    void Start () {
		
	}

    float timer = 0f;
    void Update () {
        TestByInput();
        doorLeft.MovePosition(doorLeft.position + new Vector3(-stepScale, 0, 0));
        doorRight.MovePosition(doorRight.position + new Vector3(stepScale, 0, 0));

        timer += Time.deltaTime;

        if (timer >= 0.5f) {
            doorLeft.AddForce(new Vector3(force, 0, 0), ForceMode.Impulse);
            doorRight.AddForce(new Vector3(-force, 0, 0), ForceMode.Impulse);
            timer = 0f;
            
        }

    }

    #region Test
    void OpenDoor(float speed) {
        
        
    }

    void TestByInput() {
        if (Input.GetKey(KeyCode.UpArrow))
        {   // Close doors
            doorLeft.MovePosition(doorLeft.position + new Vector3(stepScale, 0, 0));
            doorRight.MovePosition(doorRight.position + new Vector3(-stepScale, 0, 0));
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {   // Open doors
            doorLeft.MovePosition(doorLeft.position + new Vector3(-stepScale, 0, 0));
            doorRight.MovePosition(doorRight.position + new Vector3(stepScale, 0, 0));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {   // Slam close 
            print("force");
            doorLeft.AddForce(new Vector3(force, 0, 0), fMode);
            doorRight.AddForce(new Vector3(-force, 0, 0), fMode);
        }
    }
    #endregion

}

            