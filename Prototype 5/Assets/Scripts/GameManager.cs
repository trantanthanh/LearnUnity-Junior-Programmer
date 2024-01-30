using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timeIntervalSpawn = 1f;
    public TextMeshProUGUI scoreTMP;
    public TextMeshProUGUI gameOverTMP;
    public List<GameObject> targets;
    //private Coroutine spawnCoroutine;
    private int score;
    public bool isGameActive = false;
    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        score = 0;
        gameOverTMP.gameObject.SetActive(false);
        UpdateScore(0);
        //spawnCoroutine = StartCoroutine(SpawnTarget());
        StartCoroutine(SpawnTarget());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(timeIntervalSpawn);
            int randomIdx = Random.Range(0, targets.Count);
            Instantiate(targets[randomIdx]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        if (score < 0) score = 0;
        scoreTMP.text = "Score : " + score;
    }

    public void GameOver()
    {
        isGameActive = false;
        //if (spawnCoroutine != null)
        //{
        //    StopCoroutine(spawnCoroutine);
        //}
        gameOverTMP.gameObject.SetActive(true);
    }
}
