using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] spawnPrefabs;
    [SerializeField] Vector3 spawnPos;

    private float startDelay = 0f;
    [SerializeField] float timeIntervalSpawn = 1f;
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, timeIntervalSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        int prefabIndexRand = Random.Range(0, spawnPrefabs.Length);
        Instantiate(spawnPrefabs[prefabIndexRand], spawnPos, transform.rotation);
    }
}
