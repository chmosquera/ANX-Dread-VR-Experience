using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBox : MonoBehaviour
{
    private bool triggered = false;

    public void OnTriggerEnter(Collider other)
    {
        //other.name("Hello");
        
        //if (other.gameObject.layer == LayerMask.NameToLayer("NonInteractable"))
        if (other.transform.root.tag == "Player")
        {
            print("Found 'player' tag");
            triggered = true;
        }
        //else
        //{
        //    print("Triggered by: " + other.gameObject.name);
        //    triggered = true;
        //    //print(triggered);
        //}
    }
	
    public bool GetTriggered()
    {
        //print(triggered);
        return triggered;
    }
}
