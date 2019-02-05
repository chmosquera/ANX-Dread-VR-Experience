using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sound is played via its animation
// This must be attached to the object that contains the animation
public class DoorSound : MonoBehaviour {

    public AudioClip sound;
    public AudioSource audioSource;
  

    public void PlayBrokenDoorSound() {
        audioSource.PlayOneShot(sound);
    }
}
