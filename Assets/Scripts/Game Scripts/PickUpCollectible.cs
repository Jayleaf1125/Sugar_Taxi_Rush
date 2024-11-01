using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;

public class PickUpCollectible : MonoBehaviour
{
    public TextMeshProUGUI score;
    public GameObject countdownTimer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        HandleCandyPickup(other);
    }

    void HandleCandyPickup(Collider2D other)
    {
        string tag = other.tag;
        CandyStats candyStats = other.GetComponent<CandyStats>();

        switch (tag)
        {
            case "Regular Candy":
                HandleRegularCandyPickUp(candyStats);
                break;
            case "Time Candy":
                HandleTimeCandyPickup(candyStats);
                break;
            case "Hyper Candy":
                StartCoroutine(HandleHyperCandyPickup(candyStats));
                break;
            case "Size Candy":
                StartCoroutine(HandleSizeCandyPickup(candyStats));
                break;
        }
    }

    void HandleRegularCandyPickUp(CandyStats candyStats)
    {
        float score = Convert.ToInt32(this.score.text);
        score += candyStats.collectibleValue;
        this.score.text = Convert.ToString(score);
    }

    void HandleTimeCandyPickup(CandyStats candyStats) 
    {
        TimerLogic timer = countdownTimer.GetComponent<TimerLogic>();
        float increaseTimeAmount = candyStats.collectibleValue;

        float newTime = timer.remainingTime + increaseTimeAmount;
        timer.remainingTime = newTime;
    }
    IEnumerator HandleHyperCandyPickup(CandyStats candyStats) 
    {
        TopDownCarController playerStats = GetComponent<TopDownCarController>();
        float multiplier = candyStats.collectibleValue;

        playerStats.acceleration_factor *= multiplier;
        playerStats.maxSpeed *= multiplier;
        Debug.Log("Hyperspeed Gained");

        yield return new WaitForSeconds(3f);

        playerStats.acceleration_factor /= multiplier;
        playerStats.maxSpeed /= multiplier;
        Debug.Log("Hyperspeed Lost");
    }
    IEnumerator HandleSizeCandyPickup(CandyStats candyStats) 
    { 
        Transform carSize = GetComponent<Transform>();
        float multiplier = candyStats.collectibleValue;

        carSize.localScale *= multiplier;

        yield return new WaitForSeconds(3f);

        carSize.localScale /= multiplier;
    }

     
}
