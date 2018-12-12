using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenScreenScript : MonoBehaviour {

    public GameObject screen;
    public bool screenActive = false;

	// Use this for initialization
	void Start () {
        screen.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.tag != "Player") return;
        if (other.gameObject.name == "[VRTK][AUTOGEN][Controller][NearTouch][CollidersContainer]") return;       // avoid this collider in the hands (bc its huge and used for something else)
        if (other.gameObject.name == "[VRTK][AUTOGEN][BodyColliderContainer]") return;                          // also avoid the body collider
        screen.SetActive(true);
        screenActive = true;
       
    }
}
