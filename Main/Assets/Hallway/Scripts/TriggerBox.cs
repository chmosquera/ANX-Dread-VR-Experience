using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBox : MonoBehaviour
{
    private bool triggered;
    public TriggerBox()
    {
        triggered = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        print("here");
        print(other.GetComponent(tag));
        if (other.CompareTag("Player"))
        {
            triggered = true;
        }
        else
        {
            triggered = false;
        }
    }
	
    public bool GetTriggered()
    {
        return triggered;
    }
}
