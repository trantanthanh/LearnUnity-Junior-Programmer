using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] spawnPrefabs;
    [SerializeField] float timeIntervalSpawn = 1f;
    [SerializeField] float spawnPosX = 10f;
    void Start()
    {
        InvokeRepeating("SpawnObstacle", 0.0f, timeIntervalSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        int prefabIndexRand = Random.Range(0, spawnPrefabs.Length);
        Instantiate(spawnPrefabs[prefabIndexRand],new Vector3(spawnPosX, 0 ,0), transform.rotation);
    }
}
