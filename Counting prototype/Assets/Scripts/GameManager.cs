using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> foodsPrefab;
    [SerializeField] float timeSpawnMin = 0.8f;
    [SerializeField] float timeSpawnMax = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFood());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnFood()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(timeSpawnMin, timeSpawnMax));
            int randomIdx = Random.Range(0, foodsPrefab.Count);
            Instantiate(foodsPrefab[randomIdx]);
        }
    }
}
