using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationController : MonoBehaviour
{
    public GameObject[] roads; // Array of road objects
    public TopDownCarController carController;
    public GameObject destinationGameObject;
    void Start()
    {

        AssignPosition();
       
    }

    public void AssignPosition()
    {
        // Pick a random road
        GameObject selectedRoad = roads[Random.Range(0, roads.Length)];

        // Get its Collider2D
        Collider2D collider = selectedRoad.GetComponent<Collider2D>();
        if (collider != null)
        {
            Bounds bounds = collider.bounds;
            Vector2 min = bounds.min;
            Vector2 max = bounds.max;

            Vector2 randomPoint;
            int maxAttempts = 100;
            int attempts = 0;

            do
            {
                randomPoint = new Vector2(
                    Random.Range(min.x, max.x),
                    Random.Range(min.y, max.y)
                );
                attempts++;
            } while (!collider.OverlapPoint(randomPoint) && attempts < maxAttempts);

            if (attempts < maxAttempts)
            {
                // Found a valid point inside the collider
                // Store this point as a transform
                // GameObject pointMarker = new GameObject("RandomRoadPoint");
                destinationGameObject.transform.position = randomPoint;
                // Optionally, parent it to the road for organization
                destinationGameObject.transform.parent = selectedRoad.transform;
                carController.destination = destinationGameObject;
            }
            else
            {
                Debug.LogWarning("Could not find a point inside the collider after maximum attempts.");
            }
        }
        else
        {
            Debug.LogWarning("Selected road does not have a Collider2D component.");
        }
    }
}
