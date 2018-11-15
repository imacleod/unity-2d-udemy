using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    // Configuration
    [SerializeField] AudioClip breakSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }
}
