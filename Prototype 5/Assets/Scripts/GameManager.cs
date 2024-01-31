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
    public int numOfLives = 3;
    private int livesRemain;
    private float timeIntervalSpawn = 1f;
    public TextMeshProUGUI scoreTMP;
    public TextMeshProUGUI livesTMP;
    public GameObject gameOverLayout;
    public GameObject mainMenuLayout;
    public List<GameObject> targets;
    //private Coroutine spawnCoroutine;
    private int score;
    public bool isGameActive = false;
    // Start is called before the first frame update
    void Start()
    {
        livesRemain = numOfLives;
        UpdateLivesText();
        isGameActive = false;
        score = 0;
        gameOverLayout.SetActive(false);
        mainMenuLayout.SetActive(true);
        UpdateScore(0);
        //spawnCoroutine = StartCoroutine(SpawnTarget());
    }

    public void StartGame(string difficulty)
    {
        isGameActive = true;
        mainMenuLayout.SetActive(false);
        StartCoroutine(SpawnTarget());
        switch (difficulty)
        {
            case "Easy" :
                {
                    //easy
                    timeIntervalSpawn = timeIntSpawnEasy;
                    break;
                }
            case "Medium":
                {
                    //medium
                    timeIntervalSpawn = timeIntSpawnMedium;
                    break;
                }
            case "Hard":
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

    public void LostLive()
    {
        --livesRemain;
        UpdateLivesText();
        if (livesRemain <= 0)
        {
            GameOver();
        }
    }

    void UpdateLivesText()
    {
        livesTMP.text = "Lives : " + livesRemain;
    }

    void GameOver()
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
