using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DecreaseCountdownTimer : MonoBehaviour
{
    public GameObject countdownTimer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            HandleCoundownTimer();
        }
    }
    void HandleCoundownTimer()
    {
        TimerLogic timer = countdownTimer.GetComponent<TimerLogic>();
        float newTime = timer.remainingTime - 5f;
        timer.remainingTime = (newTime <= 26f ? 26f : newTime);
    }
}
