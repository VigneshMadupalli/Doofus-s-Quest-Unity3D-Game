using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private Rigidbody rb;
    public float fallThreshold = -5f; // Set a value that indicates a fall
    public GameOverManager gameOverManager; // Reference to the GameOverManager script

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical) * moveSpeed;
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }

    private void Update()
    {
        if (transform.position.y < fallThreshold)
        {
            // Call the OnPlayerFell method from GameOverManager and pass the score
            gameOverManager.OnPlayerFell(ScoreManager.Instance.score);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("NewPulpit"))
        {
            // Assuming the ScoreManager script has a method called AddScore which increments the score
            ScoreManager.Instance.AddScore(1);
        }
    }
}
