using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StartButtonState {INACTIVE, ACTIVE};

public class OpenScreenScript : MonoBehaviour {

    public ControlPanelManager manager;
    public GameObject screen;
    public bool screenActive = false;
    private StartButtonState state = StartButtonState.INACTIVE;

	// Use this for initialization
	void Start () {
        if (manager == null) print("OpenScreenScript::Missing required element.");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.tag != "Player") return;
        if (other.gameObject.name == "[VRTK][AUTOGEN][Controller][NearTouch][CollidersContainer]") return;       // avoid this collider in the hands (bc its huge and used for something else)
        if (other.gameObject.name == "[VRTK][AUTOGEN][BodyColliderContainer]") return;                          // also avoid the body collider
       
        screenActive = true;

    }
}
