using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInputHandler : MonoBehaviour
{
    TopDownCarController topDownCarController;
    public AudioClip[] audioClips;
    public AudioSource audioSorce;
    public bool check;
    public bool check2;
    // Start is called before the first frame update
    void Start()
    {
        topDownCarController = GetComponent<TopDownCarController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = Vector2.zero;

        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        topDownCarController.SetInputVector(inputVector);
        if(!Input.GetKeyDown(KeyCode.W) && !Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.D))
           
        {
            if (check == false)
            {
                audioSorce.clip = audioClips[0];
                audioSorce.Play();

                check = true;
                check2 = false;

            }


        }
        else
        {
            if(check2 == false)
            {
                audioSorce.clip = audioClips[1];

                audioSorce.Play();
                check2 = true;
                check = false;

            }

        }
    }
}
