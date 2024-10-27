using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPointert : MonoBehaviour
{
    public GameObject centerObject;  // The object to orbit around
    public GameObject targetObject;  // The object to move towards
    public float orbitRadius = 0.1f;  // Radius of the circular orbit

    void Update()
    {
        // Calculate the desired position on the circular path

            float angle = Mathf.Atan2(targetObject.transform.position.y - centerObject.transform.position.y, targetObject.transform.position.x - centerObject.transform.position.x);
            float targetX = centerObject.transform.position.x + Mathf.Cos(angle) / orbitRadius;
            float targetY = centerObject.transform.position.y + Mathf.Sin(angle) / orbitRadius;
            Vector3 targetPosition = new Vector3(targetX, targetY, transform.position.z);

            // Move the object towards the target position
            float moveSpeed = 5f; // Adjust the movement speed here
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Calculate the angle to rotate the arrow sprite
            float arrowAngle = Mathf.Atan2(targetObject.transform.position.y - transform.position.y, targetObject.transform.position.x - transform.position.x) * Mathf.Rad2Deg;

            // Apply the rotation to the arrow sprite
            transform.rotation = Quaternion.Euler(0f, 0f, arrowAngle);
      

    }
}
