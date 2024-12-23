using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 8:31 is where we left off

public class TopDownCarController : MonoBehaviour
{
    [Header("Car Settings")]
    public float acceleration_factor = 30.0f;
    public float turn_factor = 3.5f;
    public float drift_factor = 0.95f;
    public float maxSpeed = 20;

    float acceleration_input = 0;
    float steering_input = 0;
    float rotation_angle = 0;
    float velocityVsUp = 0;
    public ScreenShake ss;
    public int maxObjectIncrease = 10;

    Rigidbody2D carRigidbody;
    public RottenCandySpawner rottenCandy;
    
    public DestinationController destinationController;
    public GameObject destination;
    // Start is called before the first frame update
    void Awake()
    {
        carRigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, destination.transform.position) <= 2f)
        {
            destinationController.AssignPosition();
            //Destroy(destination.gameObject);
            ss.StartShake(0.6f, 0.6f);
            FindObjectOfType<AudioManager>().Play("win", 1, 0.5f, false);
            rottenCandy.maxObjects += 10;
            rottenCandy.Respawn();

        }
    }

    void FixedUpdate()
    {
        ApplyEngineForce();
        ApplySteering();
        KillOrthogonalVelocity();
    }

    void ApplyEngineForce()
    {
        //calculates how much foward we are going
        velocityVsUp = Vector2.Dot(transform.up, carRigidbody.velocity);
        if (velocityVsUp > maxSpeed && acceleration_input > 0)
            return;
        //limits foward velocity
        if (velocityVsUp < -maxSpeed * 0.5f && acceleration_input < 0)
            return;

        if (carRigidbody.velocity.sqrMagnitude > maxSpeed * maxSpeed && acceleration_input > 0)
            return;



        if (acceleration_input == 0)
        {
            carRigidbody.drag = Mathf.Lerp(carRigidbody.drag, 3.0f, Time.fixedDeltaTime * 3);
        }
        else
        {
            carRigidbody.drag = 0;
        }
        Vector2 engineForceVector = transform.up * acceleration_input * acceleration_factor;
        carRigidbody.AddForce(engineForceVector, ForceMode2D.Force);

    }

    void ApplySteering()
    {
        float minSpeedBeforeAllowTurningFactor = (carRigidbody.velocity.magnitude / 8);
        minSpeedBeforeAllowTurningFactor = Mathf.Clamp01(minSpeedBeforeAllowTurningFactor);

        rotation_angle -= (steering_input * turn_factor * minSpeedBeforeAllowTurningFactor);
        carRigidbody.MoveRotation(rotation_angle);  

    }

    public void SetInputVector(Vector2 inputVector)
    {
        steering_input = inputVector.x;
        acceleration_input = inputVector.y;
    }
    public void KillOrthogonalVelocity()
    {
        Vector2 fowardVelocity = transform.up * Vector2.Dot(carRigidbody.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(carRigidbody.velocity, transform.right);
        carRigidbody.velocity = fowardVelocity + rightVelocity * drift_factor;

    }
}
