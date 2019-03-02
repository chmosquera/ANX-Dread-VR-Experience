using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{

    protected HeartbeatHallwayManager hbManager;
    public string name;

    public abstract void Tick();

    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }

    public State(HeartbeatHallwayManager hbManager) {
        this.hbManager = hbManager;
        name =  "Default State";
    }

}
