using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemiesPrefab;
    public float startDelay = 0f;
    public float intervalSpawn = 3f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, intervalSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        int indexRandom = Random.Range(0, enemiesPrefab.Length);
        Instantiate(enemiesPrefab[indexRandom], new Vector3(0,0,6), enemiesPrefab[indexRandom].transform.rotation);
    }
}
