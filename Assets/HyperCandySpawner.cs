using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperCandySpawner : MonoBehaviour
{
    public GameObject[] roads;         // Array of road GameObjects
    public GameObject objectPrefab;    // Prefab of the object to spawn
    public int maxObjects = 50;        // Maximum number of objects to maintain

    private List<GameObject> spawnedObjects = new List<GameObject>();

    void Start()
    {
        // Initially spawn objects up to maxObjects
        for (int i = 0; i < maxObjects; i++)
        {
            SpawnObject();

        }
    }

    void Update()
    {
        // Clean up any destroyed objects from the list
        spawnedObjects.RemoveAll(item => item == null);

        // Spawn new objects if we have less than maxObjects
        while (spawnedObjects.Count < maxObjects)
        {
            SpawnObject();
        }
    }

    void SpawnObject()
    {
        // Pick a random road
        GameObject selectedRoad = roads[Random.Range(0, roads.Length)];

        // Get its Collider2D component
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
            }
            while (!collider.OverlapPoint(randomPoint) && attempts < maxAttempts);

            if (attempts < maxAttempts)
            {
                // Instantiate the object at the random point
                GameObject newObject = Instantiate(objectPrefab, randomPoint, Quaternion.identity);

                // Optionally, parent it to the road for organization
                newObject.transform.parent = selectedRoad.transform;

                // Add it to the list of spawned objects
                spawnedObjects.Add(newObject);
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
