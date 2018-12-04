﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenScreenScript : MonoBehaviour {

    public GameObject screen;
    public bool screenActive = false;

	// Use this for initialization
	void Start () {
        screen.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        screen.SetActive(true);
        screenActive = true;
       
    }
}
