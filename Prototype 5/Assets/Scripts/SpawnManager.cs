using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] goodItemsPrefabs;
    public GameObject[] badItemsPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        SpawnGoodItems();
        SpawnBadItem();
    }

    void SpawnGoodItems() { 
        int randomIdx = Random.Range(0, goodItemsPrefabs.Length);
        Instantiate(goodItemsPrefabs[randomIdx]);
    }

    void SpawnBadItem()
    {
        int randomIdx = Random.Range(0, badItemsPrefabs.Length);
        Instantiate(badItemsPrefabs[randomIdx]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
