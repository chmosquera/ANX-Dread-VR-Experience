using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This script is used to read all the data coming from the device. For instance,
If arduino send ->
								{"1",
								"2",
								"3",}
readQueue() will return ->
								"1", for the first call
								"2", for the second call
								"3", for the thirst call

This is the perfect script for integration that need to avoid data loose.
If you need speed and low latency take a look to wrmhlReadLatest.
*/

public class wrmhlRead : MonoBehaviour {

    public AudioSource audioSource;
    public string heartrate;

	wrmhl myDevice = new wrmhl(); // wrmhl is the bridge beetwen your computer and hardware.

	[Tooltip("SerialPort of your device.")]
	public string portName = "COM4";

	[Tooltip("Baudrate")]
	public int baudRate = 9600;


	[Tooltip("Timeout")]
	public int ReadTimeout = 100000;

	[Tooltip("QueueLenght")]
	public int QueueLenght = 1;

	void Start () {
		myDevice.set (portName, baudRate, ReadTimeout, QueueLenght); // This method set the communication with the following vars;
		//                              Serial Port, Baud Rates, Read Timeout and QueueLenght.
		myDevice.connect (); // This method open the Serial communication with the vars previously given.
	}

	// Update is called once per frame
	void Update () {
        if (myDevice.peekQueue() != null)
        {
            if (myDevice.peekQueue().Equals("not"))
                myDevice.readQueue(); // myDevice.read() return the data coming from the device using thread.
            else
            {
                heartrate = myDevice.readQueue();
                audioSource.Play();
                print("beat");
            }
        }
	}

	void OnApplicationQuit() { // close the Thread and Serial Port
		myDevice.close();
	}
}
