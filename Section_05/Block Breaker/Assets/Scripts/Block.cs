using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    // Configuration
    [SerializeField] GameObject blockParticleVFX;
    [SerializeField] AudioClip breakSound;

    // Cached reference
    Level level;

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        TriggerParticleVFX();
        Destroy(gameObject);
        FindObjectOfType<GameSession>().AddToScore();
        level.BlockDestroyed();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.IncrementBreakableBlocks();
    }

    private void TriggerParticleVFX()
    {
        GameObject particle = Instantiate(blockParticleVFX, transform.position, transform.rotation);
        Destroy(particle, 1f);
    }
}
