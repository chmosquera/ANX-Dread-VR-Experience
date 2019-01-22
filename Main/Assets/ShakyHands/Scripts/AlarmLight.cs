using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Light))]
public class AlarmLight : MonoBehaviour
{

    [SerializeField] bool isBroken = true;
    [SerializeField] Light myLight;
    [SerializeField] float iStep = 1.0f, iMax = 20.0f, iMin = 5.0f;
    public DoorState doorState;

    // Use this for initialization
    void Start()
    {
        myLight = this.GetComponent<Light>();
        if (myLight == null) Debug.LogError("AlarmLight.cs requires a light component.");

    }

    bool reachedIMax = false;
    void Update()
    {
        switch (doorState)
        {          
            case DoorState.broken:
                // pulsing intensity
                if (myLight.intensity > iMax) reachedIMax = true;
                else if (myLight.intensity < iMin) reachedIMax = false;

                if (reachedIMax) myLight.intensity -= iStep;
                else myLight.intensity += iStep;

                myLight.color = Color.red;

                // pulsing intensity
                if (myLight.intensity > iMax) reachedIMax = true;
                else if (myLight.intensity < iMin) reachedIMax = false;

                if (reachedIMax) myLight.intensity -= iStep;
                else myLight.intensity += iStep;

                break;
            case DoorState.inactive:
                myLight.intensity = 0.0f;
                break;
            default:
                myLight.color = Color.green;
                myLight.intensity = 5.0f;
                break;
        }
            

        
    }
}
