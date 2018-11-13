using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour {
    [SerializeField] State startingState;
    [SerializeField] Text textComponent;

    State state;

	// Initialization
	void Start() {
        state = startingState;
        textComponent.text = state.GetStateStory();
	}
	
	// Called once per frame
	void Update() {
        ManageState();
	}

    private void ManageState()
    {
        var nextStates = state.GetNextStates();

        // User input
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            state = nextStates[0];
        } else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            state = nextStates[1];
        } else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        // Update story
        textComponent.text = state.GetStateStory();
    }
}
