using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] spawnPrefabs;
    [SerializeField] Vector3 spawnPos;
    private PlayerController playerControllerScript;

    private float startDelay = 0f;
    //[SerializeField] float timeIntervalSpawn = 1f;
    [SerializeField] float minTimeSpawn = 1f;
    [SerializeField] float maxTimeSpawn = 2f;

    void Start()
    {
        //InvokeRepeating("SpawnObstacle", startDelay, timeIntervalSpawn);
        StartCoroutine("SpawnObstacleRandomTime");
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObstacle()
    {
        Spawn();
    }

    IEnumerator SpawnObstacleRandomTime()
    {
        while (true)
        {
            float timeInterval = Random.Range(minTimeSpawn, maxTimeSpawn);
            yield return new WaitForSeconds(timeInterval);
            Spawn();
        }
    }

    void Spawn()
    {
        if (!playerControllerScript.isGameOver)
        {
            int prefabIndexRand = Random.Range(0, spawnPrefabs.Length);
            Instantiate(spawnPrefabs[prefabIndexRand], spawnPos, transform.rotation);
        }
    }
}
