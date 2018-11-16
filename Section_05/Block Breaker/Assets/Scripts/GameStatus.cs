﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour {
    // Configuration
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int blockDestroyedPoints = 5;
    [SerializeField] TextMeshProUGUI scoreText;

    // State
    [SerializeField] int currentScore = 0;

    public void AddToScore()
    {
        currentScore += blockDestroyedPoints;
        scoreText.text = currentScore.ToString();
    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

	// Update is called once per frame
	void Update () {
        Time.timeScale = gameSpeed;
	}
}
