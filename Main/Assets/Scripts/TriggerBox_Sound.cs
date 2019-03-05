using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBox_Sound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip slamDoorSound;
    public GameObject objAppear;

    private bool triggeredOnce = false;

    void Start() {
        gameObject.GetComponent<Collider>().isTrigger = true;
        gameObject.GetComponent<MeshRenderer>().enabled = false;

        if (objAppear != null)
        {
            objAppear.GetComponent<Renderer>().enabled = false;
            objAppear.GetComponent<Collider>().isTrigger = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (triggeredOnce == true) return;

        audioSource.PlayOneShot(slamDoorSound);

        if (objAppear != null) {
            objAppear.GetComponent<Renderer>().enabled = true;
            objAppear.GetComponent<Collider>().isTrigger = false;
        }

        triggeredOnce = true;
    }
    
}
