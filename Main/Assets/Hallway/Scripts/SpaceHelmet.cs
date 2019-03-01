using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceHelmet : MonoBehaviour
{
    public Collider triggerObject;
    public bool helmetGrabbed = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider other) {
        if (other != triggerObject) return;

        helmetGrabbed = true;
    }
}
