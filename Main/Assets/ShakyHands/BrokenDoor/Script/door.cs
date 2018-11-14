using UnityEngine;
using System.Collections;

enum DoorState { Broken, Fixed};

public class door : MonoBehaviour {
	Transform doorObj;
    Animation doorAnim;

    bool isBroken = true;

    void Start()
    {
        doorObj = transform.Find("door");
        if (doorObj == null)
            Debug.LogError("Door.cs cannot find object 'door'");
        doorAnim = doorObj.GetComponent<Animation>();

        if (doorAnim == null)
            Debug.LogError("Door.cs cannot find Animation component of 'door'");
        else
            print("we good");
        isBroken = true;

    }

    void Update()
    {
        if (isBroken)
        {
            doorAnim.Play("broken");
        }
    }

    void OnTriggerEnter ( Collider obj  ){
        if (isBroken) return;
        doorAnim.Play("open");
    }

    void OnTriggerExit ( Collider obj  ){
        if (isBroken) return;
        doorAnim.Play("close");
    }
}