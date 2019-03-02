using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SpaceHelmet : MonoBehaviour
{
    public Collider wearableObj;
    public bool wearableObjHit;
    public bool helmetGrabbed = false;

    private VRTK_InteractableObject interactableObj;
    // Start is called before the first frame update
    void Start()
    {
        if ((interactableObj = gameObject.GetComponent<VRTK_InteractableObject>()) == null)
            Debug.LogError("<SpaceHelmet> Requires the component VRTK_InteractableObject");
    }

    void Update() {
        if (interactableObj.IsGrabbed() == true) {
            helmetGrabbed = true;
        }
        
    }

    void OnTriggerEnter(Collider other) {

        if (other != wearableObj && helmetGrabbed == false) {
            return;
        }

        wearableObjHit = true;
    }

    void OnTriggerExit(Collider other) {
        
    }
}
