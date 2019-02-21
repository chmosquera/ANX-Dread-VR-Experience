using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {

    float totalTime = 300f; //2 minutes
    public Text timer;
    private bool enabled = false;



    private void Update()
    {
            UpdateLevelTimer();
    }

    public void UpdateLevelTimer()
    {
        TimeSpan timeleft = GlobalCountDown.TimeLeft;
        float totalseconds = (float)timeleft.TotalSeconds;
        int minutes = Mathf.FloorToInt(totalseconds / 60f);
        int seconds = Mathf.RoundToInt(totalseconds % 60f);

        string formatedSeconds = seconds.ToString();

        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }

        timer.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
