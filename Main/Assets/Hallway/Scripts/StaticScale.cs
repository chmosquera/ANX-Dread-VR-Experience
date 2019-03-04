using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticScale : MonoBehaviour
{
    private Vector3 origProportion;
    public Transform scalingObject;


    // Start is called before the first frame update
    void Start()
    {
        origProportion = new Vector3(transform.localScale.x / scalingObject.localScale.x,
                              transform.localScale.y / scalingObject.localScale.y,
                              transform.localScale.z / scalingObject.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(origProportion.x / scalingObject.localScale.x,
                                               origProportion.y / scalingObject.localScale.y,
                                               origProportion.z / scalingObject.localScale.z);
    }
}
