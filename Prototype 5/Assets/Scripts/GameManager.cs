using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float timeIntSpawnEasy = 2f;
    public float timeIntSpawnMedium = 1f;
    public float timeIntSpawnHard = 0.5f;
    private float timeIntervalSpawn = 1f;
    public TextMeshProUGUI scoreTMP;
    public GameObject gameOverLayout;
    public GameObject mainMenuLayout;
    public List<GameObject> targets;
    //private Coroutine spawnCoroutine;
    private int score;
    public bool isGameActive = false;
    // Start is called before the first frame update
    void Start()
    {
        isGameActive = false;
        score = 0;
        gameOverLayout.SetActive(false);
        mainMenuLayout.SetActive(true);
        UpdateScore(0);
        //spawnCoroutine = StartCoroutine(SpawnTarget());
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        mainMenuLayout.SetActive(false);
        StartCoroutine(SpawnTarget());
        switch (difficulty)
        {
            case 0:
                {
                    //easy
                    timeIntervalSpawn = timeIntSpawnEasy;
                    break;
                }
            case 1:
                {
                    //medium
                    timeIntervalSpawn = timeIntSpawnMedium;
                    break;
                }
            case 2:
                {
                    //hard
                    timeIntervalSpawn = timeIntSpawnHard;
                    break;
                }
        }
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
        gameOverLayout.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isGameActive = true;
        score = 0;
        UpdateScore(0);
        mainMenuLayout.SetActive(false);
        gameOverLayout.SetActive(false);
    }
    public void RestartToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
