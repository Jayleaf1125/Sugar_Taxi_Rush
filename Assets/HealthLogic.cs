using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public Image[] healthSprites;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            health = 10;
            StartCoroutine(MoveToGameOverScreen());

        }
    }

    public void DepleteHealth()
    {
        health -= 1;

        healthSprites[health].enabled = false;
    }

    IEnumerator MoveToGameOverScreen()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadSceneAsync(1);
    }
}
