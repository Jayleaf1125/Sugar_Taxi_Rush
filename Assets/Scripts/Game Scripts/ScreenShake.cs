using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    // Start is called before the first frame update

    public static ScreenShake instance;

    private float shakeTimeRemaning;
    private float shakePower;
    private float shakeFadeTime;
    private float shakeRotation;

    public float rotationMultiplier = 7.5f;

    void Start()
    {
        instance = this;
    }

    void LateUpdate()
    {
       if(Time.timeScale == 1)
        {
            if (shakeTimeRemaning > 0)
            {
                shakeTimeRemaning -= Time.deltaTime;
                float xAmount = Random.Range(-1f, 1f) * shakePower;
                float yAmount = Random.Range(-1, 1f) * shakePower;
                transform.position += new Vector3(xAmount, yAmount, 0f);
                shakePower = Mathf.MoveTowards(shakePower, 0f, shakeFadeTime * Time.deltaTime);

                shakeRotation = Mathf.MoveTowards(shakeRotation, 0f, shakeFadeTime * rotationMultiplier * Time.deltaTime);
            }

            transform.rotation = Quaternion.Euler(0f, 0f, shakeRotation * Random.Range(-1f, -1f));
        }
     
    }

   public void StartShake(float length, float power)
    {
        shakeTimeRemaning = length;
        shakePower = power;

        shakeFadeTime = power / length;

        shakeRotation = power * rotationMultiplier;
    }
}

