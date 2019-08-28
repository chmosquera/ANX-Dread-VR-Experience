using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartBeatDisplay : MonoBehaviour {

    public GameManager gm;
    public Text hb;
    //public wrmhlRead heartrateMonitor;
    public int heartBeat;
    public int hbCounter;

    private void Start()
    {
        heartBeat = 70;
        hb.text = heartBeat.ToString();
        hbCounter = 5000;
    }
    private void Update()
    {
        UpdateHeartBeat();
    }

    public void UpdateHeartBeat()
    {

        //hb.text = heartrateMonitor.heartrate;
        // before crash, start at 70 
        if (gm.GetGameState() == GameState.Intro)
        {
            if (heartBeat < 76 && hbCounter == 0)
            {
                heartBeat++;
                hbCounter = 5000;
            }
                
        }
        // at crash, jump to 100
        else if (gm.GetGameState() == GameState.Crash)
        {
            print(hbCounter);
            if (heartBeat < 100)
                heartBeat = 100;
            else if (heartBeat < 130 && hbCounter == 0)
            {
                heartBeat++;
                hbCounter = 3000;
            }
        }
        // in maze peak at 150
        else if (gm.GetGameState() == GameState.Recover)
        {
            // heartBeat = 150;
            if (heartBeat < 150)
                heartBeat+= (int)Time.deltaTime;
        }
        hb.text = heartBeat.ToString();
        hbCounter--;
    }

    
}
