using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceMusicScript : MonoBehaviour {
    public AudioSource audioSource;
    public AudioClip audioClip;
	public bool playMusic = false;
    // Use this for initialization
    void Start() {
        //audioSource.clip = audioClip;
        //playMusic = false;
    }

    void Update()
    {

    }

    public void PlayMusic() {
        audioSource.Play();
    }
}
