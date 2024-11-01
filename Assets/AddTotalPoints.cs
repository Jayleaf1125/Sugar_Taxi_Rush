using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddTotalPoints : MonoBehaviour
{
    public TextMeshProUGUI totalScore;
    public TextMeshProUGUI candiesCollected;
    public TextMeshProUGUI timer;

    private void OnTriggerEnter2D(Collider2D other)
    {
         
        if (other.CompareTag("Player"))
        { 
        
            AddingPoints();
        }
    }

    void AddingPoints() 
    {
        TimerLogic timerLogic = timer.GetComponent<TimerLogic>();

        float numOfTotalScore = Convert.ToInt32(totalScore.text);

        float numOfCandiesCollected = Convert.ToInt32(candiesCollected.text);
        numOfCandiesCollected = numOfCandiesCollected == 0 ? 1 : numOfCandiesCollected;

        int seconds = Mathf.FloorToInt(timerLogic.remainingTime % 60);
        float newScore = numOfTotalScore + ((seconds * 100 / 2) * numOfCandiesCollected);

        totalScore.text = String.Format("{0}", newScore);
        candiesCollected.text = String.Format("0");
            


    }
}
//float score = Convert.ToInt32(this.score.text);
//float newScore = score - candyStats.collectibleValue;
//score = (newScore <= 0 ? 0 : newScore);
//this.score.text = Convert.ToString(score);