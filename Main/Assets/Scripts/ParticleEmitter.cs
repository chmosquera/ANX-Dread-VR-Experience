using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEmitter : MonoBehaviour
{
    public Sparks sparkPrefab;
    public Air airPrefab;
    private Sparks spark = null;
    private Air airhiss = null;
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
        print("hit particle sphere");
        print(other.gameObject.tag);
        if (other.gameObject.CompareTag("Player"))
        {
            print("hello");
            //Player in vacinity create steam or sparks on wal around them every couple seconds now  
            InvokeRepeating("createEffect", Random.Range(0f, 1.0f), Random.Range(2.0f, 5.0f));

        }
    }

    void createEffect()
    {
        print("yo");
        if (Random.value < .5) //make steam 
        {
            spark = Instantiate(sparkPrefab);
            print(transform.position);
            spark.transform.localPosition = transform.position;
            print(spark.transform.position);
            //spark.transform.localRotation = rotation;
        }
        else {  // make air 
            airhiss = Instantiate(airPrefab);
            airhiss.transform.localPosition = transform.position;
            print(airhiss.transform.position);
            //airhiss.transform.localRotation = rotation;
        }
    }


}
