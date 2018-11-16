using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour {
    // Configuration
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int blockDestroyedPoints = 5;

    // State
    [SerializeField] int currentScore = 0;

    public void AddToScore()
    {
        currentScore += blockDestroyedPoints;
    }

	// Update is called once per frame
	void Update () {
        Time.timeScale = gameSpeed;
	}
}
