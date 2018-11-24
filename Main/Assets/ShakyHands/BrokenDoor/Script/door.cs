using UnityEngine;
using System.Collections;

namespace SH
{

    public enum DoorState { broken, closed, opening, closing }

    public class door : MonoBehaviour
    {

        Transform doorObj;
        Animation doorAnim;
        Animator animator;

        public DoorState doorstate = DoorState.broken;

        void Start()
        {
            doorObj = transform.Find("door");
            if (doorObj == null)
                Debug.LogError("Door.cs cannot find object 'door'");

            animator = doorObj.GetComponent<Animator>();

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
            if (obj.gameObject.layer == LayerMask.NameToLayer("SH_IgnoreColliders")) return;    // ignore colliders within this layer
            doorstate = DoorState.opening;
            print("Opening door");
        }


        void OnTriggerExit(Collider obj)
        {
            if (obj.gameObject.layer == LayerMask.NameToLayer("SH_IgnoreColliders")) return;    // ignore colliders within this layer
            doorstate = DoorState.closing;
            print("Closing door");
        }
    }
}