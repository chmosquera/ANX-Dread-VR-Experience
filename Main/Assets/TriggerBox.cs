using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBox : MonoBehaviour
{
    public bool OnTrigger(Collider other)
    {
        Debug.Log("hey");
        if (other.CompareTag("Camera"))
        {
            return true;
            Debug.Log("hello");
        }
        return false;
    }
	
}
