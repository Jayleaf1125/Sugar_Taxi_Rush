using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IncreaseCountdownTimer : MonoBehaviour
{
    public GameObject countdownTimer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Destination has been reached");
            HandleCoundownTimer();
        }
    }
    void HandleCoundownTimer()
    {
        TimerLogic timer = countdownTimer.GetComponent<TimerLogic>();
        timer.intialTime -= 2f;
        timer.remainingTime = timer.intialTime;
    }
}
