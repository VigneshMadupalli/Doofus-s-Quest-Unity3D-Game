using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public Text scoreText;
    public Button restartButton;

    private void Start()
    {
        // Initially hide the game over canvas
        gameOverCanvas.SetActive(false);
        
        // Add a listener for the restart button
        restartButton.onClick.AddListener(RestartGame);
    }

    public void OnPlayerFell(int finalScore)
    {
        scoreText.text = "Score: " + finalScore;
        gameOverCanvas.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
