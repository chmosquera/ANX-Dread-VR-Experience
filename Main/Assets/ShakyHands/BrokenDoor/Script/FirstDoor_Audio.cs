using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstDoor_Audio : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;

    public void PlaySound()
    {
        audioSource.Play();
    }
}
