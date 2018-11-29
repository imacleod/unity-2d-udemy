using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour {
    float speed;

    // Initialization
    void Start ()
    {
        speed = Random.Range(360f, 720f);
    }

	// Called once per frame
	void Update () {
		transform.Rotate(0, 0, speed * Time.deltaTime);
	}
}
