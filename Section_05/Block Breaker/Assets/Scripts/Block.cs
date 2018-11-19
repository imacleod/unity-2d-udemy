﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    // Configuration
    [SerializeField] GameObject blockParticleVFX;
    [SerializeField] AudioClip breakSound;
    [SerializeField] int maxHits;

    // Cached reference
    Level level;

    // State
    [SerializeField] int timesHit;  // TODO: only serialized for debugging

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
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
    }

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void TriggerParticleVFX()
    {
        GameObject particle = Instantiate(blockParticleVFX, transform.position, transform.rotation);
        Destroy(particle, 1f);
    }
}
