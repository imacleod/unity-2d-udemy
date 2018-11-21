using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    // Configuration
    int startWave = 0;
    [SerializeField] List<WaveConfig> waveConfigs;

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int i = 0; i < waveConfig.GetEnemyCount(); i++)
        {
            GameObject enemy = Instantiate(
                waveConfig.GetEnemyPrefab(),
                waveConfig.GetWaypoints()[0].transform.position,
                Quaternion.identity);
            enemy.GetComponent<EnemyPath>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetSpawnWaitTime());
        }
    }

	// Initialization
	void Start () {
		WaveConfig currentWave = waveConfigs[startWave];
        StartCoroutine(SpawnAllEnemiesInWave(currentWave));
	}
}
