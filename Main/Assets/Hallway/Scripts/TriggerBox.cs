using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBox : MonoBehaviour
{
    private bool triggered;
    public Animator animator;
    Scene_Changer animate = new Scene_Changer(animator, 0);

    public bool OnTriggerEnter(Collider other)
    {
        Debug.Log("hey");
        if (other.CompareTag("MainCamera"))
        {
            animate.FadeToLevel(1);
        }
        return false;
    }
	
}
