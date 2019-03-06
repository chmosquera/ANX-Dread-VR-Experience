using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartBeatDisplay : MonoBehaviour {

    public Text hb;
    public wrmhlRead heartrateMonitor;

    private void Update()
    {
            UpdateHeartBeat();
    }

    public void UpdateHeartBeat()
    {

        hb.text = heartrateMonitor.heartrate;
    }
}
