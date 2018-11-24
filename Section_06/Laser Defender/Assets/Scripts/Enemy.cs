using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    // Configuration
    [SerializeField] int health = 100;
    [SerializeField] GameObject laserPrefab;
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
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Fire()
    {
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
