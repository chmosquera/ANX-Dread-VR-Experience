using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
        public Text attemptsText;


        void Start()
        {

            animator = this.GetComponentInChildren<Animator>();
            doorstate = hsDoorState.locked;

        }

        void Update()
        {
            //print("Doorstate: " + doorstate.ToString());
            //print("scan attenpts: " + scanAttempts);
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
            attemptToOpen();
        }

        void attemptToOpen()
        {
            scanAttempts++;
            if(scanAttempts == 3)
            {
                attemptsText.text = "Attempt " + (scanAttempts-2).ToString() +" out of 3.\n Lower Heart Rate to enter.\n Calm Down.";
            }
            if (scanAttempts == 4)
            {
                attemptsText.text = "Attempt " + (scanAttempts - 2).ToString() + " out of 3.\n Heart Rate is Too High to Enter.\n CALM DOWN.";
            }
            if (scanAttempts == 5)
            {
                attemptsText.text = "Attempt " + (scanAttempts - 2).ToString()  + " out of 3.\n Heart Rate is Appropriate.\n Proceed through the door.";
            }
            print("scan attemps: " + scanAttempts);
            if (scanAttempts >= 5)
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


        void OnTriggerExit(Collider obj)
        {
           if (obj.gameObject.layer == LayerMask.NameToLayer("NonInteractable")) return;    // ignore colliders within this layer
            if (doorstate == hsDoorState.locked || doorstate == hsDoorState.scanning) return;

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