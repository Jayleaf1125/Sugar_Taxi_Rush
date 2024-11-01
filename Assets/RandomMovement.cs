using UnityEngine;
using System.Collections;

public class RandomTransformMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 2f;              // Speed at which the NPC moves
    public float minMoveDuration = 1f;        // Minimum time the NPC moves in one direction
    public float maxMoveDuration = 3f;        // Maximum time the NPC moves in one direction

    [Header("Wait Settings")]
    public float minWaitDuration = 1f;        // Minimum time the NPC waits before moving again
    public float maxWaitDuration = 3f;        // Maximum time the NPC waits before moving again

    [Header("Obstacle Settings")]
    public LayerMask obstacleLayers;          // Layers that define what counts as an obstacle
    public float obstacleDetectionRadius = 0.2f; // Radius for obstacle detection

    private Vector2 movementDirection;        // Current movement direction
    private float moveDuration;               // Current movement duration
    private float waitDuration;               // Current waiting duration
    private bool isMoving = false;            // Is the NPC currently moving?

    void Start()
    {
        // Start the random movement coroutine
        StartCoroutine(MoveRoutine());
    }

    void Update()
    {
        if (isMoving)
        {
            // Check for obstacles
            if (IsObstacleAhead())
            {
                // Choose a new direction if an obstacle is detected
                movementDirection = GetRandomDirection();
            }

            // Move the NPC in the movement direction
            transform.Translate(movementDirection * moveSpeed * Time.deltaTime, Space.World);
        }
    }

    IEnumerator MoveRoutine()
    {
        while (true)
        {
            // Wait for a random duration before moving again
            waitDuration = Random.Range(minWaitDuration, maxWaitDuration);
            isMoving = false;
            yield return new WaitForSeconds(waitDuration);

            // Choose a random direction to move in
            movementDirection = GetRandomDirection();

            // Move for a random duration
            moveDuration = Random.Range(minMoveDuration, maxMoveDuration);
            isMoving = true;
            yield return new WaitForSeconds(moveDuration);
        }
    }

    Vector2 GetRandomDirection()
    {
        // Generate a random angle in radians
        float angle = Random.Range(0f, Mathf.PI * 2);
        // Convert the angle to a direction vector
        return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
    }

    bool IsObstacleAhead()
    {
        // Check if there's an obstacle in the movement direction
        Vector2 position = transform.position;
        Vector2 nextPosition = position + movementDirection * obstacleDetectionRadius;

        Collider2D hit = Physics2D.OverlapCircle(nextPosition, obstacleDetectionRadius, obstacleLayers);
        return hit != null;
    }
}
