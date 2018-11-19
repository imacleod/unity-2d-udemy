using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    // Configuration
    [SerializeField] float maxX = 15f;
    [SerializeField] float minX = 1f;
    [SerializeField] float screenWidthInUnits = 16f;

    // Cached references
    Ball ball;
    GameSession gameSession;

    // Determine x coordinate for paddle position
    private float GetPosX()
    {
        if (gameSession.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            // Set paddle transform position x to mouse's position on screen
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }

	// Initialization
	void Start () {
        ball = FindObjectOfType<Ball>();
        gameSession = FindObjectOfType<GameSession>();
	}
	
	// Called once per frame
	void Update () {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetPosX(), minX, maxX);
        transform.position = paddlePos;
	}
}
