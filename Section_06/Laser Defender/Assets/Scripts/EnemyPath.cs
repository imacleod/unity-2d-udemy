using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour {
    // Configuration
    int waypointIndex = 0;
    WaveConfig waveConfig;
    List<Transform> waypoints;

    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[0].transform.position;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            transform.position = Vector2.MoveTowards(
                transform.position,
                targetPosition,
                waveConfig.GetMoveSpeed() * Time.deltaTime);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetWaveConfig(WaveConfig config)
    {
        this.waveConfig = config;
    }
}
