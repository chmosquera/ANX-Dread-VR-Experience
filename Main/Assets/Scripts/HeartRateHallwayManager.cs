using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayManager1 : MonoBehaviour
{
    private State currentState;

    void Start()
    {
        
    }

    void Update()
    {
        currentState.Tick();
    }

    public void SetState(State state)
    {
        if (currentState != null) currentState.OnStateExit();
        currentState = state;
        if (currentState != null) currentState.OnStateEnter();
    }
}
