using UnityEngine;

public class Ball : MonoBehaviour {
    // Configuration
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float launchVelX = 2f;
    [SerializeField] float launchVelY = 15f;
    [SerializeField] Paddle paddle1;
    [SerializeField] float randomForce = 0.2f;

    // State
    Vector2 ballOffset;
    bool hasLaunched = false;

    // Cached component references
    AudioSource ballAudioSource;
    Rigidbody2D rigidBody2D;

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rigidBody2D.velocity = new Vector2(launchVelX, launchVelY);
            hasLaunched = true;
        }
    }

    // Ball follows paddle at offset
    private void LockToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + ballOffset;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 randomVelocityForce = new Vector2(Random.Range(0f, randomForce), Random.Range(0f, randomForce));
        if (hasLaunched)
        {
            ballAudioSource.PlayOneShot(ballSounds[Random.Range(0, ballSounds.Length)]);
            rigidBody2D.velocity += randomVelocityForce;
        }
    }

	// Initialization
	void Start () {
        ballAudioSource = GetComponent<AudioSource>();
        ballOffset = transform.position - paddle1.transform.position;  // Position ball above paddle
        rigidBody2D = GetComponent<Rigidbody2D>();
	}
	
	// Called once per frame
	void Update ()
    {
        if (!hasLaunched)
        {
            LockToPaddle();
            LaunchOnMouseClick();
        }
    }
}
