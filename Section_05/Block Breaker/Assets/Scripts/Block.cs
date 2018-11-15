using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    // Configuration
    [SerializeField] AudioClip breakSound;

    // Cached reference
    Level level;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.countBreakableBlocks();
    }
}
