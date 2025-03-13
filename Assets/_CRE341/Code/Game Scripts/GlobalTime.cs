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
    public float maxTime = 0; // time limit

    public bool timeFinished;

    // Update is called once per frame
    void Update()
    {
        SetTimerText();
        Timer();
    }

    private void SetTimerText() 
    {
        timerText.text = currentTime.ToString("0.0");
    }

    private void Timer() 
    {
        //currentTime = countdown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;

        if (currentTime <= 0.01f)
        {
            timeFinished = true;
            hasLimit = true;
            Debug.Log("TIME'S UP");
        }

        if (!timeFinished)
        {
            currentTime = countdown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
            hasLimit = false;
        }

        if (hasLimit && ((countdown && currentTime <= maxTime) || (countdown && currentTime >= maxTime)))
        {
            currentTime = maxTime;
            SetTimerText();
            timerText.color = Color.red;
            enabled = false;
        }
    }

}

