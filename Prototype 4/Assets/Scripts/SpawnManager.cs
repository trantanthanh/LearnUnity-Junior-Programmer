using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemiesPrefab;
    public float startDelay = 0f;
    public float intervalSpawn = 3f;
    public float spawnRadius = 8f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, intervalSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 GenerateSpawnPos()
    {
        return new Vector3(Random.Range(-spawnRadius, spawnRadius), 0, Random.Range(-spawnRadius, spawnRadius));
    }

    void SpawnEnemy()
    {
        int indexRandom = Random.Range(0, enemiesPrefab.Length);
        Instantiate(enemiesPrefab[indexRandom], GenerateSpawnPos(), enemiesPrefab[indexRandom].transform.rotation);
    }
}
