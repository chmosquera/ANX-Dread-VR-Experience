using UnityEngine;
using System.Collections;

namespace SH
{

    public enum DoorState { broken, closed, opening, closing }

    public class door : MonoBehaviour
    {

        Animator animator;
        public DoorState doorstate = DoorState.broken;
        public bool initBroke = false;

        void Start()
        {

            animator = this.GetComponentInChildren<Animator>();
            doorstate = DoorState.broken;

        }

        void Update()
        {
            print("Doorstate: " + doorstate.ToString());
            switch (doorstate) {
                case DoorState.broken:
                    animator.SetBool("isBroken", true);
                    animator.SetBool("isOpening", false);
                    animator.SetBool("isClosing", false);
                    break;
                case DoorState.opening:
                    animator.SetBool("isBroken", false);
                    animator.SetBool("isOpening", true);
                    animator.SetBool("isClosing", false);
                    break;
                case DoorState.closing:
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

        void OnTriggerEnter(Collider obj)
        {
            if (obj.gameObject.layer == LayerMask.NameToLayer("NonInteractable")) return;    // ignore colliders within this layer
            if (doorstate == DoorState.broken) return;
            doorstate = DoorState.opening;
            print("Opening door");
        }


        void OnTriggerExit(Collider obj)
        {
            if (obj.gameObject.layer == LayerMask.NameToLayer("NonInteractable")) return;    // ignore colliders within this layer
            if (doorstate == DoorState.broken) return;
            doorstate = DoorState.closing;
            print("Closing door");
        }

        public void SetBroken() {
            if (initBroke) return;

            doorstate = DoorState.broken;
            initBroke = true;
        
        }
    }
}