using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusSphere : MonoBehaviour {
    private float fadeSpeed = 0.5f;
    public bool fadeActive = false;
    public GameObject[] objList;

	// Use this for initialization
	void Start () {
        //Material[] mats = this.GetComponentsInChildren<Material>();
        //print("Material count: " + mats.Length);
	}
	
	// Update is called once per frame
	void Update () {
        if (fadeActive) {
            foreach (GameObject obj in objList)
            {
                Color color = obj.GetComponent<MeshRenderer>().material.color;
                color.a -= Time.deltaTime * fadeSpeed;
                obj.GetComponent<MeshRenderer>().material.color = color;
            }
        }
        
    }

}
