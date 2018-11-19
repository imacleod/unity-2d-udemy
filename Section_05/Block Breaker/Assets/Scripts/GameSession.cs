using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour {
    // Configuration
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int blockDestroyedPoints = 5;
    [SerializeField] bool isAutoPlayEnabled;
    [SerializeField] TextMeshProUGUI scoreText;

    // State
    [SerializeField] int currentScore = 0;

    public void AddToScore()
    {
        currentScore += blockDestroyedPoints;
        scoreText.text = currentScore.ToString();
    }

    private void Awake()
    {
        // Singleton pattern for game status persistence across levels
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            // Deactivate object before destruction to prevent execution order related bugs
            gameObject.SetActive(false);
            ResetGame();
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
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
