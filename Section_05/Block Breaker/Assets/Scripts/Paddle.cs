using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    // Configuration
    [SerializeField] float maxX = 15f;
    [SerializeField] float minX = 1f;
    [SerializeField] float screenWidthInUnits = 16f;

	// Initialization
	void Start () {
	}
	
	// Called once per frame
	void Update () {
        // Set paddle transform position x to mouse's position on screen
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        paddlePos.x = Mathf.Clamp(mousePosInUnits, minX, maxX);
        transform.position = paddlePos;
	}
}
