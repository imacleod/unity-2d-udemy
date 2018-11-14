using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    // Configuration
    [SerializeField] Paddle paddle1;

    // State
    Vector2 ballOffset;

	// Initialization
	void Start () {
        ballOffset = transform.position - paddle1.transform.position;
	}
	
	// Called once per frame
	void Update () {
        // Ball follows paddle at offset
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + ballOffset;
	}
}
