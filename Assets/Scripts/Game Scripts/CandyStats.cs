using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CandyStats : MonoBehaviour
{
    public float collectibleValue = 1f;
    public ScreenShake ss;


    public void Start()
    {
        ss = GameObject.FindObjectOfType<ScreenShake>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            ss.StartShake(0.5f, 0.5f);
            FindObjectOfType<AudioManager>().Play("CandyImpact", 1, 0.3f, false);

        }
    }

}
