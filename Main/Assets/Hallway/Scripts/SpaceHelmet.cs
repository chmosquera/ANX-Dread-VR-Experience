using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SpaceHelmet : MonoBehaviour
{
    public Collider triggerByObject;

    public Transform snapToPosition;

    private VRTK_InteractableObject interactableObj;
    private bool moveToPosition = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
        if ((interactableObj = gameObject.GetComponent<VRTK_InteractableObject>()) == null)
            Debug.LogError("<SpaceHelmet> Requires the component VRTK_InteractableObject");
    }

    void Update() {
//        Debug.Log ("object is grabbed: " + interactableObj.IsGrabbed());

        if (moveToPosition) {
            
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, snapToPosition.position, 0.01f); 

            if (gameObject.transform.position == snapToPosition.position) {
                gameObject.transform.parent = snapToPosition;
                moveToPosition = false;
                Debug.Log("AT THE POSITION");
            }
        }
        

        //Debug.Log ("object's parent: " + gameObject.transform.parent.name);
    }

    void OnTriggerEnter(Collider other) {

        if (other!=triggerByObject || interactableObj.IsGrabbed() == false) return;
        Debug.Log("helmet hit the head");

        gameObject.GetComponent<StaticScale>().enabled = false;
        interactableObj.ForceStopInteracting();
        moveToPosition = true;
        
    
    }

    void OnTriggerExit(Collider other) {
        
    }
}
