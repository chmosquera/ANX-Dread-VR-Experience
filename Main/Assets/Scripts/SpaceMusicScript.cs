using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceMusicScript : MonoBehaviour {
    public ShakyHandsManager shManager;
    public AudioSource audioSource;
    public AudioClip audioClip;
    // Use this for initialization
    void Start() {
        audioSource.clip = audioClip;
        //playMusic = false;
    }

    void Update()
    {
        if (shManager.playMusic)
        {
            audioSource.Play();
        }
    }
}
