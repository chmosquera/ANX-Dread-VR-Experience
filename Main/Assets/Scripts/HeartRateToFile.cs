using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class HeartRateToFile : MonoBehaviour
{

    public wrmhlRead hrMonitor;
    private System.IO.StreamWriter file;
    public string location;

    // Start is called before the first frame update
    void Start()
    {
        string now = DateTime.Now.ToString("hh_mm_ss");
        //print(now);
        string nameOfFile = "userStats" + location + now + ".txt";
        file = new System.IO.StreamWriter(@"C:\Users\rdevito\Desktop\CIA\CIACapstone\CIACapstone\Main\heartRateStats\" + nameOfFile);
 
    }

    // Update is called once per frame
    void Update()
    {
        string rate = hrMonitor.heartrate;
        print("heelo");
        //if (isNumeric(rate))
        //{
            file.WriteLine(Time.time.ToString() + "\t" + rate + "\n");
        //}
    }

    public bool isNumeric(string value)
    {
        int test;
        return int.TryParse(value, out test);
    }

    void OnApplicationQuit()
    {
        file.Close();
    }

}
