using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PickedUp : MonoBehaviour
{
    public GameObject collectiblePrefab;
    public TextMeshProUGUI pointSystemScore;
    public int collectibleValue;

    private void Awake()
    {
        pointSystemScore = pointSystemScore.GetComponent<TextMeshProUGUI>();    
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.tag == "Player")
        {
        
             int score = Convert.ToInt32(pointSystemScore.text);
             UpdateScore(score);

            Destroy(collectiblePrefab);
        }
    }

    private void UpdateScore(int score)
    {
        score += collectibleValue;
        pointSystemScore.text = Convert.ToString(score);
    }
}
