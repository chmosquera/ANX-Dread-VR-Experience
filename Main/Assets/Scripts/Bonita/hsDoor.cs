using UnityEngine;
using System.Collections;

namespace SH
{

    public enum hsDoorState { locked, opening, closing, scanning }

    public class hsDoor : MonoBehaviour
    {

        Animator animator;
        public hsDoorState doorstate = hsDoorState.locked;
        //public GameObject scanner;
        public bool initLocked = false;
        public int scanAttempts = 0;

        void Start()
        {

            animator = this.GetComponentInChildren<Animator>();
            doorstate = hsDoorState.locked;

        }

        void Update()
        {
            //print("Doorstate: " + doorstate.ToString());
            switch (doorstate) {
                case hsDoorState.opening:
                    animator.SetBool("isBroken", false);
                    animator.SetBool("isOpening", true);
                    animator.SetBool("isClosing", false);
                    break;
                case hsDoorState.closing:
                    animator.SetBool("isBroken", false);
                    animator.SetBool("isOpening", false);
                    animator.SetBool("isClosing", true);
                    break;
                default:
                    animator.SetBool("isBroken", false);
                    animator.SetBool("isOpening", false);
                    animator.SetBool("isClosing", false);
                    break;
            }

        }

        public void scanOccurred()
        {
            print("recieved message from scanner");
            StartCoroutine(Example());
            attemptToOpen();
        }

        IEnumerator Example()
        {
            print(Time.time);
            yield return new WaitForSeconds(5);
            print(Time.time);
        }

        void attemptToOpen()
        {
            //StartCoroutine(Example());
            scanAttempts++;
            print("scan attemps: " + scanAttempts);
            if (scanAttempts >= 3)
            {
                doorstate = hsDoorState.opening;
                return;
            }
            else
            {
                doorstate = hsDoorState.locked;
            }

        }
       

        void OnTriggerEnter(Collider obj)
        {
            if (obj.gameObject.layer == LayerMask.NameToLayer("NonInteractable")) return;    // ignore colliders within this layer
            if (doorstate == hsDoorState.locked || doorstate == hsDoorState.scanning) return;
            doorstate = hsDoorState.opening;
            print("Opening door");
        }

        void myWait(float stop)
        {
            float delta = 0;
            float start = Time.time;
            float end = Time.time;
            do
            {
                delta = start - end;
            } while (delta < stop);
        }

        void OnTriggerExit(Collider obj)
        {
           if (obj.gameObject.layer == LayerMask.NameToLayer("NonInteractable")) return;    // ignore colliders within this layer
            if (doorstate == hsDoorState.locked || doorstate == hsDoorState.scanning) return;
            //wait 
            myWait(3);

           doorstate = hsDoorState.closing;
           print("Closing door");
        }

        public void SetBroken() {
            if (initLocked) return;

            doorstate = hsDoorState.locked;
            initLocked = true;
        
        }
    }
}