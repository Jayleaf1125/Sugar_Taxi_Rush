using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TimerLogic : MonoBehaviour
{
    public TextMeshProUGUI countdownTimer;
    public float intialTime = 60f;
    public float remainingTime;

    private void Awake()
    {
        remainingTime = intialTime;
    }

    private void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }  else if (remainingTime < 0) 
        {
            remainingTime = 0;
            countdownTimer.color = Color.red;
        }


        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        countdownTimer.text = string.Format("{0:00}: {1:00}", minutes, seconds);
    }
}
