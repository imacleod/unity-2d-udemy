using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour {
    int score = 0;

    private void Awake()
    {
        Singleton();
    }

    public int GetScore () {
		return score;
	}
	
	public void IncreaseScore (int points) {
		score += points;
	}

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    private void Singleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
