using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnChecker : MonoBehaviour
{

    public Collider NospawnZone;
    MapGenerator MG;
    [SerializeField] private float maxAttempts = 1000f;
    [SerializeField] private float raycastHeight = 50f;
    [SerializeField] private int numberOfNPCs;
    public GameObject groundObject;
    public GameObject npcPrefab;


    [SerializeField] List<GameObject> npcs = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        //Assign nospawnZeon
    }
    private void Update()
    {
        SpawnNPCs(numberOfNPCs);
    }

    private void SpawnNPCs(int count)
    {
        int maxAttempts = 1000;
        for (int i = 0; i < count; i++)
        {
            Vector3 randomNPCPos = Vector3.zero;
            bool validPositionFound = false;
            int attempts = 0;

            while (!validPositionFound && attempts < maxAttempts)
            {
                randomNPCPos = GetRandomGroundPoint();
                if (randomNPCPos != Vector3.zero)
                {
                    NavMeshHit hit;
                    if (NavMesh.SamplePosition(randomNPCPos, out hit, 1.0f, NavMesh.AllAreas))
                    {
                        randomNPCPos = hit.position;

                        if (!NospawnZone.bounds.Contains(randomNPCPos))
                        {
                            validPositionFound = false;
                            Debug.Log("Bounds does not contain the point : " + randomNPCPos);
                        }
                    }
                }
                attempts++;
            }

            if (validPositionFound)
            {
                Instantiate(npcPrefab, randomNPCPos, Quaternion.identity);
                // add the NPC to the list
                npcs.Add(npcPrefab);
            }
            else
            {
                Debug.LogWarning("Failed to find a valid NavMesh point for NPC.");
            }
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

}
