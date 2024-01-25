using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemiesPrefab;
    public float startDelay = 0f;
    public float intervalSpawn = 3f;
    public float spawnRadius = 8f;
    private Vector3 spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, intervalSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RandomSpawnPos()
    {
        spawnPos = new Vector3(Random.Range(-spawnRadius, spawnRadius), 0, Random.Range(-spawnRadius, spawnRadius));
    }

    void SpawnEnemy()
    {
        RandomSpawnPos();
        int indexRandom = Random.Range(0, enemiesPrefab.Length);
        Instantiate(enemiesPrefab[indexRandom], spawnPos, enemiesPrefab[indexRandom].transform.rotation);
    }
}
