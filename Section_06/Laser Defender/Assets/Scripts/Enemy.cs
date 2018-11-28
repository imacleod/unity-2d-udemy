using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    // Configuration
    [Header("Attributes")]
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0, 1)] float deathSFXVolume = 0.75f;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration = 1f;
    [SerializeField] int health = 100;
    [SerializeField] int scoreValue = 100;

    [Header("Projectile")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] AudioClip laserSFX;
    [SerializeField] [Range(0, 1)] float laserSFXVolume = 0.75f;
    [SerializeField] float laserSpeed = 10f;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] float shotCountdown;

    private void CountDownAndShoot()
    {
        // Unify shots and game frames
        shotCountdown -= Time.deltaTime;
        if (shotCountdown <= 0)
        {
            Fire();
            InitiateShotCountdown();
        }
    }

    private void DamageTaken(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        FindObjectOfType<GameSession>().IncreaseScore(scoreValue);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSFXVolume);
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(explosion, explosionDuration);
        Destroy(gameObject);
    }

    private void Fire()
    {
        AudioSource.PlayClipAtPoint(laserSFX, Camera.main.transform.position, laserSFXVolume);
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laserSpeed);  // invert laserSpeed to move down screen
    }

    private void InitiateShotCountdown()
    {
        shotCountdown = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) {  return; }
        DamageTaken(damageDealer);
    }

    // Initialization
    void Start () {
        InitiateShotCountdown();
	}
	
	// Called once per frame
	void Update () {
        CountDownAndShoot();
	}
}
