using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HallwayState { INACTIVE, ACTIVE, END}

public class Hallway2MusicPlayer : MonoBehaviour
{
   
    public bool doorFixed = false;
    public AudioSource audioSource;
    public AudioClip snd_hallway;
    public AudioClip snd_ending;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = snd_hallway;
    }

    // Update is called once per frame
    void Update()
    {

        InitState_Ending(); // will execute only once, when door becomes fixed

        audioSource.Play();
    }


    void InitState_Ending()
    {
        if (doorFixed) return;

        audioSource.clip = snd_ending;
    }
}
