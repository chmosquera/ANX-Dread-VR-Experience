using System;
using UnityEngine;

namespace SH
{
    public class Scanner : MonoBehaviour
    {
        public hsDoor myDoor;
        [SerializeField] GameObject scanner;
        public float start, end;
        public float delta = 0;

        void Start()
        {
            if (scanner == null) Debug.LogError("Could not find scanner");

        }

        void OnTriggerEnter(Collider obj)
        {
            print("collision");
            if (myDoor.doorstate == hsDoorState.locked)
            {
                print("door is locked");
                if (obj.gameObject.layer == LayerMask.NameToLayer("NonInteractable")) return;    // ignore colliders within this layer
                start = Time.time;
                if (delta != 0) //not first time 
                {
                    myDoor.doorstate = hsDoorState.scanning;
                }
                //print("start:" + start);
            }
        }

        void OnTriggerExit(Collider obj)
        {
            if (myDoor.doorstate == hsDoorState.scanning || delta == 0)
            {
                if (obj.gameObject.layer == LayerMask.NameToLayer("NonInteractable")) return;    // ignore colliders within this layer
                end = Time.time;
                //print("end:" + end);
                delta = end - start;
                print("delta:" + delta);
                if (delta > 3)
                {
                    print("scan occurred for 3 seconds");
                    myDoor.scanOccurred();
                }
                else
                {
                    myDoor.doorstate = hsDoorState.locked;
                }
            }

        }



    }
}
