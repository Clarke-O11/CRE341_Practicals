using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Unity.AI.Navigation;
using UnityEngine.AI;
using Random = UnityEngine.Random;
using UnityEditor.ShaderGraph.Internal;

public class SpawnItems : MonoBehaviour
{

    public GameObject itemPrefab, waypointsPrefab; // Reference to item prefab
	public GameObject groundObject;
    [SerializeField] int numberOfItems = 5;
    [SerializeField] List<GameObject> items = new List<GameObject>();

    [SerializeField] int numberWaypoints = 4;
    [SerializeField] List<GameObject> waypoints = new List<GameObject>();

    [SerializeField] private int maxAttempts = 1000; // Safety limit to avoid an infinite loop.

    [SerializeField] public NavMeshSurface surface;
    [SerializeField] private float raycastHeight = 50f; // Height above the plane from which to cast rays.


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnWayPoints(numberWaypoints);
        ItemSpawner(numberOfItems);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GameObject[] go_items = GameObject.FindGameObjectsWithTag("Items");
            foreach (GameObject item in go_items) Destroy(item);
            ItemSpawner(numberOfItems);

            GameObject[] go_wps = GameObject.FindGameObjectsWithTag("Waypoint");
            foreach (GameObject wp in go_wps) Destroy(wp);
            SpawnWayPoints(numberWaypoints);
        }
    }

    public Vector3 GetRandomGroundPoint()
    {
        Bounds groundBounds = groundObject.GetComponent<Renderer>().bounds;

        for (int i = 0; i < maxAttempts; i++)
        {
            // Pick a random position within the specified X-Z range, at a fixed height.
            float randX = Random.Range(groundBounds.min.x, groundBounds.max.x);
            float randZ = Random.Range(groundBounds.min.z, groundBounds.max.z);
            Vector3 origin = new Vector3(randX, raycastHeight, randZ);

            // Cast a ray straight down.
            if (Physics.Raycast(origin, Vector3.down, out RaycastHit hit, Mathf.Infinity))
            {
                // Check if the first hit collider is tagged "Ground".
                if (hit.collider.CompareTag("Ground"))
                {
                    return hit.point;
                }
            }
        }

        // If no suitable point is found after maxAttempts, return a default.
        Debug.LogWarning("No valid 'Ground' point found.");
        return Vector3.zero;
    }

    private void ItemSpawner(int count)
    { 
        int maxAttempts = 1000;
        for (int i = 0; i < count; i++)
        {
            Vector3 randomItemPos = Vector3.zero;
            bool validPositionFound = false;
            int attempts = 0;

            while (!validPositionFound && attempts < maxAttempts)
            {
                randomItemPos = GetRandomGroundPoint();
                if (randomItemPos != Vector3.zero)
                {
                    NavMeshHit hit;
                    if (NavMesh.SamplePosition(randomItemPos, out hit, 1.0f, NavMesh.AllAreas))
                    {
                        randomItemPos = hit.position;
                        validPositionFound = true;
                    }
                }
                attempts++;
            }

            if (validPositionFound)
            {
                Instantiate(itemPrefab, randomItemPos, Quaternion.identity);
                // add the Item to the list
                items.Add(itemPrefab);
            }
            else
            {
                Debug.LogWarning("Failed to find a valid NavMesh point for Item.");
            }
        }
    }

    private void SpawnWayPoints(int count)
    {

        for (int i = 0; i < count; i++)
        {
            Vector3 randomItemPos = Vector3.zero;
            bool validPositionFound = false;
            int attempts = 0;

            while (!validPositionFound && attempts < maxAttempts)
            {
                randomItemPos = GetRandomGroundPoint();
                if (randomItemPos != Vector3.zero)
                {
                    NavMeshHit hit;
                    if (NavMesh.SamplePosition(randomItemPos, out hit, 1.0f, NavMesh.AllAreas))
                    {
                        randomItemPos = hit.position;
                        validPositionFound = true;
                    }
                }
                attempts++;
            }

            if (validPositionFound)
            {
                Instantiate(waypointsPrefab, randomItemPos, Quaternion.identity);
                // add the Item to the list
                waypoints.Add(waypointsPrefab);
            }
            else
            {
                Debug.LogWarning("Failed to find a valid NavMesh point for Waypoint.");
            }
        }
    }
}
