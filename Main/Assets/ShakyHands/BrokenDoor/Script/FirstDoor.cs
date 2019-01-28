using UnityEngine;
using System.Collections;

public enum DoorState { inactive, broken, closed, opening, closing }

public class FirstDoor : MonoBehaviour
{

    Animator animator;
    //public GameManager manager;
    public DoorState state = DoorState.inactive;
    private bool initBroken = false;

    void Start()
    {

        animator = this.GetComponentInChildren<Animator>();
        state = DoorState.inactive;

    }

    void Update()
    {
        //print("Doorstate: " + doorstate.ToString());
        switch (state) {
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
        if (obj.gameObject.name != "[VRTK][AUTOGEN][BodyColliderContainer]") return;   // Only wait for body to collide
        if (state == DoorState.broken) return;
        state = DoorState.opening;
        print("Opening door");
    }


    void OnTriggerExit(Collider obj)
    {
        if (obj.gameObject.layer == LayerMask.NameToLayer("NonInteractable")) return;    // ignore colliders within this layer
        if (obj.gameObject.name != "[VRTK][AUTOGEN][BodyColliderContainer]") return;   // Only wait for body to collide
        if (state == DoorState.broken) return;
        state = DoorState.closing;
        print("Closing door");
    }

    public void InitiateBroken()
    {
        if (initBroken) return; // Already broke, don't initiate break again

        state = DoorState.broken;
        initBroken = true;
    }
}