using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;

public class PickUpCollectible : MonoBehaviour
{
    public TextMeshProUGUI score;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Regular Candy"))
        {
            Debug.Log("Candy was collected was collected");
            HandleRegularCandyPickUp(other);
        }
    }

    void HandleRegularCandyPickUp(Collider2D other)
    {
        RegularCandyStats regularCandyStats = other.GetComponent<RegularCandyStats>();

        if (regularCandyStats != null)
        {
            int score = Convert.ToInt32(this.score.text);
            score += regularCandyStats.collectibleValue;
            this.score.text = Convert.ToString(score);
        }
    }
}
