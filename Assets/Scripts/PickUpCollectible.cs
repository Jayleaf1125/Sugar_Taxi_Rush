using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Debug.Log("Coin was collected");
        }
    }
}
