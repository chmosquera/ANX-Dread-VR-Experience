using System;
using System.Collections;
using UnityEngine;

namespace SH
{
    public class Scanner : MonoBehaviour
    {

        private bool scannable = true;
        public bool animationDone = true;
        public hsDoor myDoor;
        private Vector3 moveDown = new Vector3(0f, -.01f, 0f);
        private Vector3 moveUp = new Vector3(0f, .01f, 0f);
        private Vector3 startScannerPos;
        public Rigidbody handScanner;
        [SerializeField] GameObject scanner;

        void Start()
        {
            if (scanner == null) Debug.LogError("Could not find scanner");
            startScannerPos = handScanner.position;

        }

        void OnTriggerEnter(Collider obj) 
        {
            print("collision");
            if (myDoor.doorstate == hsDoorState.locked)
            {
 
                if (obj.gameObject.layer == LayerMask.NameToLayer("NonInteractable")) return;    // ignore colliders within this layer
                print("door is locked");
                if (scannable)
                {
                    print("scanning");
                    if(myDoor.scanAttempts < 2 )
                    {
                        myDoor.scanOccurred();
                        scannable = true;
                    }
                    else {
                        StartCoroutine("scanAnimation");
                    }
            
                }

            }
        }

        IEnumerator scanAnimation()
        {
            print("scan Animation");
            myDoor.doorstate = hsDoorState.scanning;
            animationDone = false;
            scannable = false;
            float curY = handScanner.position.y;
            float bottomY = curY - .3f;

            while (curY >= bottomY)
            {
                Vector3 newPosition = handScanner.position + moveDown;
                handScanner.transform.position = newPosition;
                curY = handScanner.position.y;
                //print("updated: " + curY);
                yield return new WaitForEndOfFrame();
            }
            while (curY <= startScannerPos.y)
            {
                Vector3 newPosition = handScanner.position + moveUp;
                handScanner.position = newPosition;
                curY = handScanner.position.y;
                //print("updated: " + curY);
                yield return new WaitForEndOfFrame();
            }
            myDoor.doorstate = hsDoorState.locked;
            animationDone = true;
            myDoor.scanOccurred();
            scannable = true;
        }

        void OnTriggerExit(Collider obj)
        {

            if (obj.gameObject.layer == LayerMask.NameToLayer("NonInteractable")) return;    // ignore colliders within this layer
            StartCoroutine("waitForHandRemoval");
            if (scannable == false && animationDone == true)
            {
                myDoor.scanOccurred();
                scannable = true;
            }

        }

        IEnumerator waitForHandRemoval()
        {
            yield return new WaitForSeconds(2.0f);
        }




    }
}
