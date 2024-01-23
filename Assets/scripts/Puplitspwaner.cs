using UnityEngine;
using System.Collections;

namespace Assets.scripts
{
    public class PulpitSpawner : MonoBehaviour
    {
        public GameObject pulpitPrefab;
        private GameObject currentPulpit;
        public float spawnDelay = 2f;
        public float pulpitLifetime = 5f;

        private void Start()
        {
            // Spawn the first pulpit
            currentPulpit = Instantiate(pulpitPrefab, Vector3.zero, Quaternion.identity);
            Invoke(nameof(SpawnAndDestroyNextPulpit), spawnDelay);
        }

        private void SpawnAndDestroyNextPulpit()
        {
            if (currentPulpit != null)
            {
                Vector3 nextPosition = GetNextPulpitPosition();
                GameObject newPulpit = Instantiate(pulpitPrefab, nextPosition, Quaternion.identity);
                newPulpit.tag = "NewPulpit"; // Tag the new pulpits

                Destroy(currentPulpit, pulpitLifetime); // Schedule the destruction of the current pulpit
                currentPulpit = newPulpit; // Update the current pulpit reference
            }

            Invoke(nameof(SpawnAndDestroyNextPulpit), spawnDelay);
        }

        private Vector3 GetNextPulpitPosition()
        {
            // Assuming each pulpit is 9x9
            float pulpitSize = 9f;
            Vector3 direction = RandomDirection();
            return currentPulpit.transform.position + direction * pulpitSize;
        }

        private Vector3 RandomDirection()
        {
            int choice = Random.Range(0, 4);
            switch (choice)
            {
                case 0: return Vector3.forward;
                case 1: return Vector3.back;
                case 2: return Vector3.left;
                case 3: return Vector3.right;
            }
            return Vector3.forward;
        }
    }
}