﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    // Configuration
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float launchVelX = 2f;
    [SerializeField] float launchVelY = 15f;
    [SerializeField] Paddle paddle1;

    // State
    Vector2 ballOffset;
    bool hasLaunched = false;

    // Cached component references
    AudioSource ballAudioSource;

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(launchVelX, launchVelY);
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
        if (hasLaunched)
        {
            ballAudioSource.PlayOneShot(ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)]);
        }
    }

	// Initialization
	void Start () {
        ballAudioSource = GetComponent<AudioSource>();
        ballOffset = transform.position - paddle1.transform.position;
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
