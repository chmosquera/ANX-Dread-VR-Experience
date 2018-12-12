using System;
using UnityEngine;

namespace SH
{
    public class Scanner : MonoBehaviour
    {
        public hsDoor myDoor;
        [SerializeField] GameObject scanner;

        void Start()
        {
            if (scanner == null) Debug.LogError("Could not find scanner");

        }

        void OnTriggerEnter(Collider other)
        {
            print("Collision");
            myDoor.scanOccurred();
        }



    }
}
