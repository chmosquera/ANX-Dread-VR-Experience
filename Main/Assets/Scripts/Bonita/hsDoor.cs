using UnityEngine;
using System.Collections;

namespace SH
{

    public enum hsDoorState { locked, opening, closing }

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
            print("Scanner Hit");
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
            StartCoroutine(Example());
            scanAttempts++;
            if(scanAttempts > 3)
            {
                doorstate = hsDoorState.opening;
            }

        }
       

        void OnTriggerEnter(Collider obj)
        {
            if (obj.gameObject.layer == LayerMask.NameToLayer("NonInteractable")) return;    // ignore colliders within this layer
            if (doorstate == hsDoorState.locked) return;
            doorstate = hsDoorState.opening;
            print("Opening door");
        }


        void OnTriggerExit(Collider obj)
        {
            if (obj.gameObject.layer == LayerMask.NameToLayer("NonInteractable")) return;    // ignore colliders within this layer
            if (doorstate == hsDoorState.locked) return;
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