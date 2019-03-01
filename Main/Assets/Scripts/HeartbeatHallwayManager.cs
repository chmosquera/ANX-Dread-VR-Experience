using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SH;

public class HeartbeatHallwayManager : MonoBehaviour
{
    public hsDoor doorObj;
    public AudioSource audioSource;
    public AudioClip endMusic;
    public AudioClip hallwayMusic;


    public GameObject helmet;

    [SerializeField] private State currentState;

    void Start()
    {
        SetState(new WalkingThroughState(this));
    }

    void Update()
    {
        currentState.Tick();
    }

    public void SetState(State state)
    {
        if (currentState == state) return;  

        if (currentState != null) currentState.OnStateExit();
        currentState = state;
        if (currentState != null) currentState.OnStateEnter();
    }

}
