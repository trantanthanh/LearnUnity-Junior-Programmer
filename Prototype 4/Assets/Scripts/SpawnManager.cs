using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemiesPrefabs;
    public GameObject[] powerUpPrefabs;
    public float startDelay = 0f;
    public float intervalSpawn = 3f;
    public float spawnRadius = 8f;

    public float timerMinSpawnPowerUp = 8f;
    public float timerMaxSpawnPowerUp = 15f;

    public int enemyCount;
    public int waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnEnemy", startDelay, intervalSpawn);
        SpawnEnemyWave(waveNumber);
        //StartCoroutine("RandomTimeSpawnPowerUp");
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            ++waveNumber;
            SpawnEnemyWave(waveNumber);
        }
    }

    Vector3 GenerateSpawnPos()
    {
        return new Vector3(Random.Range(-spawnRadius, spawnRadius), 0, Random.Range(-spawnRadius, spawnRadius));
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            SpawnEnemy();
        }
        SpawnPowerUp();
    }

    void SpawnEnemy()
    {
        int indexRandom = Random.Range(0, enemiesPrefabs.Length);
        Instantiate(enemiesPrefabs[indexRandom], GenerateSpawnPos(), enemiesPrefabs[indexRandom].transform.rotation);
    }

    IEnumerator RandomTimeSpawnPowerUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(timerMinSpawnPowerUp, timerMaxSpawnPowerUp));
            SpawnPowerUp();
        }
    }

    void SpawnPowerUp()
    {
        int powerUpCount = FindObjectsOfType<PowerUp>().Length;
        if (powerUpCount > 0) { 
            return; 
        }
        int indexRandom = Random.Range(0, powerUpPrefabs.Length);
        Instantiate(powerUpPrefabs[indexRandom], GenerateSpawnPos(), powerUpPrefabs[indexRandom].transform.rotation);
    }
}
