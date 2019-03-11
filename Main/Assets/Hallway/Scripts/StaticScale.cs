using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticScale : MonoBehaviour
{
    private Vector3 scaleRatio;
    private Vector3 origScale;
    public Transform scalingObject;


    // Start is called before the first frame update
    void Start()
    {
        origScale = transform.localScale;
        scaleRatio = new Vector3(transform.localScale.x / scalingObject.localScale.x,
                              transform.localScale.y / scalingObject.localScale.y,
                              transform.localScale.z / scalingObject.localScale.z);

                              
    }

    // Update is called once per frame
    void Update()
    {
        
        //Vector3 prev = transform.localScale;

        if (transform.parent == scalingObject) {
            transform.localScale = new Vector3(scaleRatio.x / scalingObject.localScale.x,
                                               scaleRatio.y / scalingObject.localScale.y,
                                               scaleRatio.z / scalingObject.localScale.z);
        } else {
            transform.localScale = origScale;
        }                                   
        //print("helmet scale: " + prev + " -> " + transform.localScale + "\t hallway scale: " + scalingObject.localScale);        
                                               
    }
}
