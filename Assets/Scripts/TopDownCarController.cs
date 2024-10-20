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

    float acceleration_input = 0;
    float steering_input = 0;
    float rotation_angle = 0;

    Rigidbody2D carRigidbody;

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
        
    }

    void FixedUpdate()
    {
        ApplyEngineForce();
        ApplySteering();
    }

    void ApplyEngineForce()
    {
        Vector2 engineForceVector = transform.up * acceleration_input * acceleration_factor;
        carRigidbody.AddForce(engineForceVector, ForceMode2D.Force);
    }

    void ApplySteering()
    {
        rotation_angle -= (steering_input * turn_factor);
        carRigidbody.MoveRotation(rotation_angle);  
    }

    public void SetInputVector(Vector2 inputVector)
    {
        steering_input = inputVector.x;
        acceleration_input = inputVector.y;
    }
}
