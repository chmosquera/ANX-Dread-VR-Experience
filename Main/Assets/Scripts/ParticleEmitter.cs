using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEmitter : MonoBehaviour
{
    public Sparks sparkPrefab;
    public Air airPrefab;
    private Sparks spark = null;
    private Air airhiss = null;
    private bool triggered = false;
    public Quaternion rotation;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //print("hit particle sphere");
        //print(other.gameObject.tag);
        if ((other.gameObject.CompareTag("Player") ||
             other.transform.parent.gameObject.CompareTag("Player") 
            )&& triggered == false)
        {
            //print("hello");
            triggered = true;
            //Player in vacinity create steam or sparks on wal around them every couple seconds now  
            //InvokeRepeating("createEffect", Random.Range(0f, 1f), Random.Range(3.0f, 5.0f));
            createEffect();
        }
    }

    void createEffect()
    {
        if (Random.value < .5) //make steam 
        {
            spark = Instantiate(sparkPrefab);
            spark.transform.localPosition = new Vector3(transform.position.x, transform.position.y, (transform.position.z -1.5f));
        }
        else {  // make air 
            airhiss = Instantiate(airPrefab);
            airhiss.transform.localPosition = new Vector3(transform.position.x, transform.position.y, (transform.position.z - 1.5f));
        }
    }


}
