using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSelectScript : MonoBehaviour {
    public ControlPanelManager manager;
    public bool charSelect = false;
    ////public FocusSphere f;
    // Use this for initialization
    void Start () {
        if (manager == null) print("OpenScreenScript::Missing required element.");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.tag != "Player") return;
        if (other.gameObject.name == "[VRTK][AUTOGEN][Controller][NearTouch][CollidersContainer]") return;       // avoid this collider in the hands (bc its huge and used for something else)
        if (other.gameObject.name == "[VRTK][AUTOGEN][BodyColliderContainer]") return;                          // also avoid the body collider

        charSelect = true;

    }
}
