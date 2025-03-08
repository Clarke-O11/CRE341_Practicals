using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GlobalTime : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float currentTime; // start time
    public bool countdown; // is timer counting down

    public bool hasLimit;
    public float maxTime; // time limit

    // Update is called once per frame
    void Update()
    {
        currentTime = countdown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        if(hasLimit && ((countdown && currentTime <= maxTime) || (countdown && currentTime >= maxTime)))
        {
            currentTime = maxTime;
            SetTimerText();
            timerText.color = Color.red;
            enabled = false;
        }

        SetTimerText();
    } 

    private void SetTimerText() 
    {
        timerText.text = currentTime.ToString("0.0");
    }

}

