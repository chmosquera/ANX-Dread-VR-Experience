using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCake : MonoBehaviour
{
    public GameObject credits;

    void Start()
    {
        credits.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        print("entered");
        print(other.transform.root.tag);
        if (other.transform.root.tag == "Player")
        {
            print("collided");
            Destroy(this.gameObject);

            credits.SetActive(true);
        }
    }
    // Update is called once per frame
   
}
