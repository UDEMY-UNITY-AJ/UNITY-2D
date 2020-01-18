using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] bool looping = false;

    private int startingWave;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do {
            yield return StartCoroutine(SpawnAllWaves());
        } while (looping);
        
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig) {
        for (int i = 0; i < waveConfig.GetNumberOfEnemies(); i++) {
            var newEnemy = Instantiate(
            waveConfig.GetEnemyPrefab(),
            waveConfig.GetPathWaypoints()[0].transform.position,
            Quaternion.identity
            );

            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);

            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }

    private IEnumerator SpawnAllWaves() {
        for (int i = startingWave; i < waveConfigs.Count; i++) {
            var currentWave = waveConfigs[i];

            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
