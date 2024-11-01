using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public List<GameObject> hearts;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnCollisionEnter2D(Collider2D other)
    {
        Debug.Log("CO");
        if(other.CompareTag("Building"))
        {
            StartCoroutine(HandleHealth());
        }
    }

    IEnumerator HandleHealth()
    {

        int selectedHeart = hearts.Count-1;
        hearts[selectedHeart].SetActive(false);
        Destroy(hearts[selectedHeart]);
        hearts.RemoveAt(selectedHeart);
        Debug.Log("Health lost");

        if (hearts.Count <= 0)
        {
            TopDownCarController carController = GetComponent<TopDownCarController>();
            carController.enabled = false;

            yield return new WaitForSeconds(2f);
            SceneManager.LoadSceneAsync(1);
        }

        yield return 0;
    }
}
