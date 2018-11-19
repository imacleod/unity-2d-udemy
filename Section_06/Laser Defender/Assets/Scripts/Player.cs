using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    // Configuration
    [SerializeField] float moveSpeed = 10f;

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newPosX = transform.position.x + deltaX;
        var newPosY = transform.position.y + deltaY;
        transform.position = new Vector2(newPosX, newPosY);
    }

	// Initialization
	void Start () {
		
	}
	
	// Called once per frame
	void Update () {
		Move();
	}
}
