using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour {
    Text healthText;
    Player player;

	// Initialization
	void Start () {
        healthText = GetComponent<Text>();
        player = FindObjectOfType<Player>();
	}
	
	// Called once per frame
	void Update () {
        healthText.text = player.GetHealth().ToString();
	}
}
