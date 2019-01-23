using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyComponentB : MonoBehaviour
{
    public Collider shakyHandTrigger;

    [Tooltip("Attach VRTK Controller Alias")]
    public Transform leftControllerScriptAlias;

    [Tooltip("Attach VRTK Controller Alias")]
    public Transform rightControllerScriptAlias;

    private Transform leftHandModel;
    private Transform rightHandModel;

    // Use this for initialization
    void Start()
    {
        leftHandModel = leftControllerScriptAlias.Find("VRTK_LeftBasicHand").Find("Model");
        rightHandModel = rightControllerScriptAlias.Find("VRTK_RightBasicHand").Find("Model");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other) {
        if (other.transform.root.tag != "Player") return;

        float x_l = (float)leftHandModel.localPosition.x;
        x_l += (Time.deltaTime *0.5f* Random.Range(-1f, 1f));
        x_l = Mathf.Clamp(x_l, -0.1f, 0.1f);
            
        float x_r = (float)rightHandModel.localPosition.x;
        x_r += (Time.deltaTime*0.5f * Random.Range(-1f, 1f));
        x_r = Mathf.Clamp(x_r, -0.1f, 0.1f);

        //print("Shaking!! - Left: " + x_l + "\tRight:" + x_r);

        leftHandModel.localPosition = new Vector3(x_l, 0, 0);
        rightHandModel.localPosition = new Vector3(x_r, 0, 0);
    }

    void OnTriggerExit(Collider other) {
        leftHandModel.localPosition = new Vector3(0, 0, 0);
        rightHandModel.localPosition = new Vector3(0, 0, 0);
    }
}
