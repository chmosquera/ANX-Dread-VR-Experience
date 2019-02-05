using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StartButtonState {INACTIVE, ACTIVE}; // is this being used?

public class OpenScreenScript : MonoBehaviour {

    public ControlPanelManager manager;
    public GameObject screen;
    public bool screenActive = false;
    ////public FocusSphere f;
    private StartButtonState state = StartButtonState.INACTIVE; // is this being used?
    private bool initStart = false;
    public AudioSource audioSource;
    public AudioClip audioClip;
    // Use this for initialization
    void Start () {
        if (manager == null) print("OpenScreenScript::Missing required element.");
        audioSource.clip = audioClip;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.tag != "Player") return;
        if (other.gameObject.name == "[VRTK][AUTOGEN][Controller][NearTouch][CollidersContainer]") return;       // avoid this collider in the hands (bc its huge and used for something else)
        if (other.gameObject.name == "[VRTK][AUTOGEN][BodyColliderContainer]") return;                          // also avoid the body collider
       
        screenActive = true;
        
        if (!initStart)
        {
            // play sound here
            initStart = true;
            audioSource.Play();
        }

    }
}
