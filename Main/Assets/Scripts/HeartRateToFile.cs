using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class HeartRateToFile : MonoBehaviour
{

    public wrmhlRead hrMonitor;
    private System.IO.StreamWriter file;

    // Start is called before the first frame update
    void Start()
    {
        string now = DateTime.Now.ToString("hh_mm_ss");
        print(now);
        string nameOfFile = "userStats" + now + ".txt";
        file = new System.IO.StreamWriter(@"C:\Users\rdevito\Desktop\CIA\CIACapstone\CIACapstone\Main\heartRateStats\" + nameOfFile);
    }

    // Update is called once per frame
    void Update()
    {
        file.WriteLine(Time.time.ToString() + "\t" + hrMonitor.heartrate + "\n");
    }

    void OnApplicationQuit()
    {
        file.Close();
    }

}
