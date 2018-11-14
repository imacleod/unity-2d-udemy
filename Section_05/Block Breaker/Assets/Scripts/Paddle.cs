using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] float screenWidthInUnits = 16f;

	// Initialization
	void Start () {
		
	}
	
	// Called once per frame
	void Update () {
        // Set paddle transform position to mouse's position on screen
        float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        transform.position = new Vector2(mousePosInUnits, transform.position.y);
	}
}
