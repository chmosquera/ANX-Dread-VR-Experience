using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCake : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        print("entered");
        print(other.transform.root.tag);
        if (other.transform.root.tag == "Player")
        {
            print("collided");
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
   
}
