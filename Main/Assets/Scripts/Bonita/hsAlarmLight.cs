using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH
{
    [RequireComponent(typeof(Light))]
    public class hsAlarmLight : MonoBehaviour
    {

        [SerializeField] bool isLocked = true;
        public Light myLight;
        [SerializeField] float iStep = 1.0f, iMax = 20.0f, iMin = 5.0f;
        public hsDoor myDoor;


        // Use this for initialization
        void Start()
        {
            myLight = this.GetComponent<Light>();
            if (myLight == null) Debug.LogError("AlarmLight.cs requires a light component.");

        }

        bool reachedIMax = false;
        void Update()
        {
            if (myDoor.doorstate == hsDoorState.locked)
            {

                myLight.color = Color.red;

                // pulsing intensity
                if (myLight.intensity > iMax) reachedIMax = true;
                else if (myLight.intensity < iMin) reachedIMax = false;

                if (reachedIMax) myLight.intensity -= iStep;
                else myLight.intensity += iStep;

            } else if (myDoor.doorstate == hsDoorState.scanning)
            {
                myLight.color = Color.blue;
                myLight.intensity = 5.0f;
            }
            else
            {
                myLight.color = Color.green;
                myLight.intensity = 5.0f;

            }
        }
    }
}