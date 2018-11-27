using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour {

    public AudioClip sound;
    public AudioSource audioSource;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void PlayBrokenDoorSound() {
        audioSource.PlayOneShot(sound);
    }
}
