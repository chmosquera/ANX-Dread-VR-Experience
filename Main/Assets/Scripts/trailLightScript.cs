using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailLightScript : MonoBehaviour {
    [SerializeField] private Light lightOne;
    [SerializeField] private Light lightTwo;
    [SerializeField] private Light lightThree;
    [SerializeField] private Light lightFour;
    [SerializeField] private Light lightFive;

    private int state;
    private int count;

    private float intense;

    public bool useLights = true;

    // Use this for initialization
    void Start()
    {
        state = 0;
        count = 0;

        intense = lightOne.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        if (useLights)
            lightTask();
        else
            lightsOff();

    }

    public void lightTask()
    {
        if (state == 0)
        {
            lightOne.intensity = intense;
            lightTwo.intensity = 0f;
            lightThree.intensity = 0f;
            lightFour.intensity = 0f;
            lightFive.intensity = 0f;

            count += 1;

            if (count >= 75)
            {
                state = 1;
                count = 0;
            }
        }
        else if (state == 1)
        {
            lightOne.intensity = 0f;
            lightTwo.intensity = intense;
            lightThree.intensity = 0f;
            lightFour.intensity = 0f;
            lightFive.intensity = 0f;

            count += 1;

            if (count >= 75)
            {
                state = 2;
                count = 0;
            }
        }
        else if (state == 2)
        {
            lightOne.intensity = 0f;
            lightTwo.intensity = 0f;
            lightThree.intensity = intense;
            lightFour.intensity = 0f;
            lightFive.intensity = 0f;

            count += 1;

            if (count >= 75)
            {
                state = 3;
                count = 0;
            }
        }
        else if (state == 3)
        {
            lightOne.intensity = 0f;
            lightTwo.intensity = 0f;
            lightThree.intensity = 0f;
            lightFour.intensity = intense;
            lightFive.intensity = 0f;

            count += 1;

            if (count >= 75)
            {
                state = 4;
                count = 0;
            }
        }
        else
        {
            lightOne.intensity = 0f;
            lightTwo.intensity = 0f;
            lightThree.intensity = 0f;
            lightFour.intensity = 0f;
            lightFive.intensity = intense;

            count += 1;

            if (count >= 75)
            {
                state = 0;
                count = 0;
            }
        }
    }

    public void lightsOff()
    {
        lightOne.intensity = 0f;
        lightTwo.intensity = 0f;
        lightThree.intensity = 0f;
        lightFour.intensity = 0f;
        lightFive.intensity = 0f;
    }
}
