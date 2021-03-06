﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject {
    // Configuration
    [SerializeField] int enemyCount = 5;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float spawnWaitTime = 0.5f;
    [SerializeField] float spawnRandomness = 0.3f;

    public int GetEnemyCount() { return enemyCount; }

    public GameObject GetEnemyPrefab() { return enemyPrefab; }

    public float GetMoveSpeed() { return moveSpeed; }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waveWaypoints = new List<Transform>();
        foreach (Transform waypoint in pathPrefab.transform)
        {
            waveWaypoints.Add(waypoint);
        }
        return waveWaypoints;
    }

    public float GetSpawnWaitTime() { return spawnWaitTime; }

    public float GetSpawnRandomness() { return spawnRandomness; }
}
