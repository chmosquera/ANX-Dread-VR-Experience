using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyComponentA : MonoBehaviour
{

    KeyComponentB key;
    [SerializeField] private FirstDoor door;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        print("Key collision enter: key not atttached yet");
        if (other.transform.GetComponent<KeyComponentB>() != null)
        {
            // Attach B to this object
            other.transform.SetParent(this.transform);
            //Destroy(other.transform.GetComponent<Rigidbody>());

            // Open door
            door.state = DoorState.closed;
      
        }
    }

    void OnCollisionStay(Collision other)
    {
        //print("trigger");
    }

    void OnCollisionExit(Collision other)
    {
        //print("trigger");
    }
}
