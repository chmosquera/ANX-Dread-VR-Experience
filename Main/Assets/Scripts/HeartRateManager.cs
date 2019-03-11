using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartRateManager : MonoBehaviour
{

    public GameManager gm;
    public HeartRateToFile crash;
    public HeartRateToFile puzzle;
    public HeartRateToFile maze;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //starts with crash active 
        if(gm.GetGameState() == GameState.Recover && crash.gameObject.activeSelf)
        {
            crash.gameObject.SetActive(false);
            puzzle.gameObject.SetActive(true);
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.CompareTag("Player") || other.transform.parent.gameObject.CompareTag("Player"))
        {
            print("HELLO");
            puzzle.gameObject.SetActive(false);
            maze.gameObject.SetActive(true);
        }
    }


}
