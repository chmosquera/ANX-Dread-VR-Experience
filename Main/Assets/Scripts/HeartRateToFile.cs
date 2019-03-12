using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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
        string sourceFolder = Application.dataPath;
        string nameOfFile = "userStats" + location + now + ".txt";
        //file = new System.IO.StreamWriter(@"C:\Users\ckait\OneDrive - California Polytechnic State University\CIACapstone\Main\Assets\heartRateStats\" + nameOfFile);
        //System.IO.Directory.CreateDirectory(sourceFolder + "\\heartRateStats\\" + now);
        file = new StreamWriter(@sourceFolder + "\\heartRateStats\\" + nameOfFile);
 
    }

    // Update is called once per frame
    void Update()
    {        
        string rate = hrMonitor.heartrate;
        
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
