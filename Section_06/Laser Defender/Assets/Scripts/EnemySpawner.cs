using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    // Configuration
    [SerializeField] bool loopWaves = false;
    [SerializeField] int startWave = 0;
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

    private IEnumerator SpawnAllWaves()
    {
        for (int i = startWave; i < waveConfigs.Count; i++)
        {
		    WaveConfig currentWave = waveConfigs[i];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }

	// Initialization
	IEnumerator Start () {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (loopWaves);
	}
}
