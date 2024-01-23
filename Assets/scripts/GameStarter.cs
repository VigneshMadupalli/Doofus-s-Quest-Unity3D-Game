using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public GameObject doofus;
    public PulpitSpawner pulpitSpawner;

    void Start()
    {
        // Initially, Doofus is inactive
        doofus.SetActive(false);

        // Activate Doofus after the first pulpit is supposed to appear
        Invoke(nameof(ActivateDoofus), pulpitSpawner.spawnDelay);
    }

    void ActivateDoofus()
    {
        // Activate Doofus
        doofus.SetActive(true);
    }
}
