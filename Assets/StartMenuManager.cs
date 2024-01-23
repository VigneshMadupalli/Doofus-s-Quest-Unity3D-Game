using UnityEngine;

public class StartMenuManager : MonoBehaviour
{
    public GameObject startMenuCanvas; // Assign your Start Menu Canvas to this field in the Inspector

    void Update()
    {
        if (Input.anyKeyDown)
        {
            startMenuCanvas.SetActive(false);
            // Add any additional logic here if needed when the game starts
        }
    }
}
