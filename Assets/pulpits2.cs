using UnityEngine;

public class PulpitSpawner : MonoBehaviour
{
    public GameObject pulpitPrefab; // Assign this in the prefab
    public float spawnDelay = 2f;
    public float pulpitLifetime = 5f; // Lifetime of the pulpit

    private void Start()
    {
        // Invoke the spawning of the next pulpit after a delay
        Invoke(nameof(SpawnNextPulpit), spawnDelay);
    }

    private void SpawnNextPulpit()
    {
        Vector3 nextPosition = GetNextPulpitPosition();
        Instantiate(pulpitPrefab, nextPosition, Quaternion.identity);
        // Schedule this pulpit to be destroyed after its lifetime
        Destroy(gameObject, pulpitLifetime);
    }

    private Vector3 GetNextPulpitPosition()
    {
        // Logic to determine the position of the next Pulpit
        // This should be based on the current pulpit's position
        // For example, spawn the next pulpit at a random adjacent position
        Vector3 direction = RandomDirection();
        float pulpitSize = 9f; // Assuming a 9x9 pulpit size
        return transform.position + direction * pulpitSize;
    }

    private Vector3 RandomDirection()
    {
        Vector3[] possibleDirections = {
            Vector3.forward,
            Vector3.left,
            Vector3.right
            // Excluding Vector3.back to not spawn backwards
        };

        int choice = Random.Range(0, possibleDirections.Length);
        return possibleDirections[choice];
    }
}
